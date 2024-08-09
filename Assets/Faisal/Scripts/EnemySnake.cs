using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnake : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f;
    private Vector2 startingPosition;
    private int direction = 1;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        if (Vector2.Distance(startingPosition, transform.position) >= moveDistance)
        {
            direction *= -1;
        }
    }
}
