using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChallengeTrigger : MonoBehaviour
{
    [SerializeField] string SceneName;
    [SerializeField] GameObject player;
    public GameObject canvasp;
    public int currentChallenge;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (currentChallenge == 1)
        {
            if (GameManager.Instance.challenge1complete)
                gameObject.SetActive(false);
        }else if (currentChallenge == 2)
        {
            if (GameManager.Instance.challenge2complete)
                gameObject.SetActive(false);
        }
        else if (currentChallenge == 3) {
            if (GameManager.Instance.challenge3complete)
                gameObject.SetActive(false);
        }
    }

    private void TriggerScene()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.challengeNum = currentChallenge;
            GameManager.Instance.canTravel = true;
            canvasp.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            canvasp.SetActive(false);
            GameManager.Instance.canTravel = false;
        }
    }

   
}
