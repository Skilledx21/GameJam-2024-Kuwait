using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FISH AI Randomly moving around the sea with a radius for Roaming follow player when near to it
/// made for game jam 2024 by rakan alhulail
/// </summary>
public class FishAI : MonoBehaviour
{
    public float roamSpeed;
    public float detectRadius;
    public float moveSpeed;
    public float roamRadius; 
    public Transform player;
    public LayerMask playerLayer;

    private Vector2 startPoint; 
    private Vector2 roamPoint;  

    private void Start()
    {
        roamSpeed = 1f;
        detectRadius = 3f;
        moveSpeed = 3f;
        roamRadius = 4f;
        startPoint = transform.position; 
        StartCoroutine(Roam());
    }


    private void Update()
    {
        DetectPlayer();

        if (player != null)
        {
            MoveTowardsPlayer();
        }
        else
        {
            MoveTowardsRoamPoint();
        }
    }

    private void DetectPlayer()
    {
        
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectRadius, playerLayer);

        if (playerCollider != null)
        {
            player = playerCollider.transform; 
        }
        else
        {
            player = null; 
        }
    }

    private IEnumerator Roam()
    {
        while (true)
        {
            SetNewRoamPoint();
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
    }

    private void SetNewRoamPoint()
    {
      
        roamPoint = startPoint + Random.insideUnitCircle * roamRadius;
    }

    private void MoveTowardsRoamPoint()
    {
        
        Vector2 direction = (roamPoint - (Vector2)transform.position).normalized;
        transform.Translate(direction * roamSpeed * Time.deltaTime, Space.World);

        
        RotateTowardsDirection(direction);

       
        if (Vector2.Distance(transform.position, roamPoint) < 0.1f)
        {
            SetNewRoamPoint();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

        
        RotateTowardsDirection(direction);
    }

    private void RotateTowardsDirection(Vector2 direction)
    {
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
        transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(startPoint, roamRadius);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //GAME OVER
            GameManagerDeepDive.instance.GameOver();
        }
    }
}
