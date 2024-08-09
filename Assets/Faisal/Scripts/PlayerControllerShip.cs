using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerControllerShip : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D rb;

    private float moveinput;

    public bool isMoving = false;

    public GameObject Net;
    private bool NetThrown = false;

    private bool canMove = true;
    private bool isVibrating = false;
    private bool caughtFishinNet = false;
    private Coroutine vibrationCoroutine;
    private Coroutine catchtimerCoroutine;

     Animator netanimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        netanimator = Net.GetComponent<Animator>();
    }

   
    void Update()
    {

        if (canMove)
        {

            moveinput = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(moveinput * speed, 0);

            isMoving = Mathf.Abs(moveinput) != 0;

        }
        else {

            rb.velocity = Vector2.zero;
        }
        




        if (Input.GetMouseButtonDown(0))
        {

            if (UIManagerFishing.Instance.gameStarted)
            {
                if (!NetThrown)
                {
                    ThrowNet();
                }
                else
                {
                    RaiseNet();
                }
            }

            
            

        }
        

        
    }


    private void ThrowNet()
    {

        

        netanimator.Play("Throw");
        Debug.Log("Thrown Net");
        NetThrown = true;
        caughtFishinNet = false;
        canMove = false;

        float CatchfishDelay = Random.Range(5f, 15f);
        Invoke("CaughtFish", CatchfishDelay);
    }
    private void RaiseNet()
    {
        netanimator.Play("RaiseNet");
        Debug.Log("Raise Net");
        NetThrown = false;
        
        canMove = true;
        isVibrating = false;

        if (caughtFishinNet)
        {
            Debug.Log("You Caught Fish!");
            int randomNumber = Random.Range(2, 6);
            UIManagerFishing.Instance.IncreaseFishAmount(randomNumber);

            
        }
        if (vibrationCoroutine != null)
        {
            StopCoroutine(vibrationCoroutine);
            vibrationCoroutine = null;
        }
        

        if (catchtimerCoroutine != null)
        {
            StopCoroutine(catchtimerCoroutine);
            catchtimerCoroutine = null;
        }

        CancelInvoke("CaughtFish");
    }
    private void CaughtFish()
    {
        Debug.Log("Net is Vibrating");
        isVibrating = true;
       vibrationCoroutine = StartCoroutine(VibrateNet());

        if (catchtimerCoroutine != null)
        {
            StopCoroutine(catchtimerCoroutine);
        }
        catchtimerCoroutine = StartCoroutine(catchTimer());
    }
    
    private IEnumerator VibrateNet()
    {
        Vector3 originalPosition = Net.transform.position;
        float vibrationIntensity = 0.1f;
        while (isVibrating)
        {
            caughtFishinNet = true;
            float offsetX = Random.Range(-vibrationIntensity, vibrationIntensity);
            float offsetY = Random.Range(-vibrationIntensity, vibrationIntensity);
            Net.transform.position = new Vector3(originalPosition.x + offsetX, originalPosition.y + offsetY, originalPosition.z);

            yield return new WaitForSeconds(0.05f); // Adjust the speed of vibration by changing the wait time
        }
        Net.transform.position = originalPosition;
    }

    private IEnumerator catchTimer()
    {
        yield return new WaitForSeconds(2f);

        if (isVibrating)
        {
            Debug.Log("Fish escaped!");
            caughtFishinNet = false;
            RaiseNet();
        }

    }
}
