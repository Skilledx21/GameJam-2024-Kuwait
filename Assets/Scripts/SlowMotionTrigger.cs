using UnityEngine;

public class SlowMotionTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.slowMoDuration = 5f;
            GameManager.Instance.StartSlowMotion();
            //other.transform.position = GameManager.Instance._QuestionTeleportArea.position;
        }
    }
}
