using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingGame_Fish : MonoBehaviour
{

    [SerializeField] private float swimSpeed = 2f;
    [SerializeField] private float changeDirectionTime = 2f;

    private Vector2 swimDirection;
    private float timeToChangeDirection;

    private Rigidbody2D rb;
    private bool movingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.gravityScale = 0;
        }

        SetRandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        Swim();
        ChangeDirectionIfNeeded();
    }

    private void Swim()
    {

        transform.Translate(swimDirection * swimSpeed * Time.deltaTime);
    }

    private void ChangeDirectionIfNeeded()
    {
        timeToChangeDirection -= Time.deltaTime;

        // If it's time to change direction
        if (timeToChangeDirection <= 0)
        {
            SetRandomDirection();
        }


    }
    private void Flip()
    {
        // Randomly choose to move left (-1) or right (1)
        float direction = Random.Range(0, 2) == 0 ? -1f : 1f;

        // Set the swim direction based on the random direction
        swimDirection = new Vector2(direction, 0);

        // Flip the fish's sprite if changing direction
        if (direction > 0 && !movingRight)
        {
            Flip();
        }
        else if (direction < 0 && movingRight)
        {
            Flip();
        }

        // Reset the timer for the next direction change
        timeToChangeDirection = changeDirectionTime;
    }

    private void SetRandomDirection()
    {

        float randomDirection = Random.Range(0, 2) == 0 ? -1f : 1f;
        swimDirection = new Vector2(randomDirection, 0); 

        timeToChangeDirection = 0f;
        Debug.Log("Changing Directions");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Net"))
        {
            Caught();
        }
    }

    private void Caught()
    {
        Debug.Log("Caught");
    }
}
