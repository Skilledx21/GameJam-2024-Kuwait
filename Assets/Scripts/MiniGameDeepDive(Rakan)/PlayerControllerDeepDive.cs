using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerDeepDive : MonoBehaviour
{
    float _pSpeed = 5f;


    Rigidbody2D rb;


    float _InputX;
    float _InputY;

    [SerializeField]bool isFlipped;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isFlipped = false;
    }

    private void FixedUpdate()
    {
        _InputX = Input.GetAxis("Horizontal");
        _InputY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(_InputX * _pSpeed, _InputY * _pSpeed);


        if (isFlipped == false)
        {
            if (rb.velocity.y > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 120);
            }
            else if (rb.velocity.y < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 60);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }else
        {
            if (rb.velocity.y > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, -120);
            }
            else if (rb.velocity.y < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, -60);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
        }

    }
}
