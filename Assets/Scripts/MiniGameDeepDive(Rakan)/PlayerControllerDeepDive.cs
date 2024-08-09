using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Movement for the diving 
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerDeepDive : MonoBehaviour
{
    float _pSpeed = 5f;
    float rotationSpeed;


    Rigidbody2D rb;


    float _InputX;
    float _InputY;

    [SerializeField]bool isFlipped;

    private void Start()
    {
        rotationSpeed = 3f;
        rb = GetComponent<Rigidbody2D>();
        isFlipped = false;
    }

    private void FixedUpdate()
    {
        if (GameManagerDeepDive.instance._lose) {
            rb.velocity = Vector2.zero;
            return; //Stop the Controller when dead
        } 


        _InputX = Input.GetAxis("Horizontal");
        _InputY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(_InputX * _pSpeed, _InputY * _pSpeed);

        FlipPlayer();
        PlayerMovement();

    }
    void PlayerMovement()
    {
        Quaternion targetRotation;

        if (isFlipped == false)
        {
            if (rb.velocity.y > 0)
            {
                targetRotation = Quaternion.Euler(0, 0, 120);
            }
            else if (rb.velocity.y < 0)
            {
                targetRotation = Quaternion.Euler(0, 0, 60);
            }
            else
            {
                targetRotation = Quaternion.Euler(0, 0, 90);
            }
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                targetRotation = Quaternion.Euler(0, 0, -120);
            }
            else if (rb.velocity.y < 0)
            {
                targetRotation = Quaternion.Euler(0, 0, -60);
            }
            else
            {
                targetRotation = Quaternion.Euler(0, 0, -90);
            }
        }

        // Smoothly rotate to the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void FlipPlayer()
    {
        if (rb.velocity.x < 0)
        {
            isFlipped = true;
        }
        else if (rb.velocity.x > 0)
        {
            isFlipped = false;
        }
    }

}
