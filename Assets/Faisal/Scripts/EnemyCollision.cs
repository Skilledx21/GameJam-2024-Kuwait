using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float playerHeight = collision.gameObject.GetComponent<Collider2D>().bounds.size.y;
            float enemyHeight = GetComponent<Collider2D>().bounds.size.y;
            float contactPoint = collision.contacts[0].point.y;

            
            if (contactPoint > transform.position.y + enemyHeight / 2)
            {
                Destroy(gameObject); 
            }
            else
            {
                
            }
        }
    }
}
