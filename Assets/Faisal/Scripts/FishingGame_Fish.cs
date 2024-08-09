using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingGame_Fish : MonoBehaviour
{

    [SerializeField] private float swimSpeed = 2f;

    private Vector2 swimDirection;
    private float ChangeDirectionTime = 2f;
    [SerializeField]private float timeuntilChangeDirection = 2f;

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


        timeuntilChangeDirection -= Time.deltaTime;

        if (timeuntilChangeDirection <= 0f)
        {
            SetRandomDirection();
            timeuntilChangeDirection = ChangeDirectionTime;
        }

    }

    private void Swim()
    {

        transform.Translate(swimDirection * swimSpeed * Time.deltaTime);
    }

    private void SetRandomDirection()
    {
        // Randomly choose to move left (-1) or right (1)
        float direction = Random.Range(0, 2) == 0 ? -1f : 1f;

        // Set the swim direction based on the random direction
        swimDirection = new Vector2(direction, 0); // Move only on the X-axis

        // Flip the fish's sprite if changing direction
        if (direction > 0 && !movingRight)
        {
            Flip();
        }
        else if (direction < 0 && movingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Flip the fish horizontally
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        // Toggle the movingRight flag
        movingRight = !movingRight;
    }


   
    
}
