using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    private Animator danimator;
    private bool doorOpen;
    void Start()
    {
        danimator = GetComponent<Animator>();
        if (GameManager.Instance.keysGained == 3)
        {
            danimator.Play("DoorOpen");
            doorOpen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (doorOpen)
        {
            Debug.Log("Mabrook");
            SceneManager.LoadScene(0);
        }
    }
}
