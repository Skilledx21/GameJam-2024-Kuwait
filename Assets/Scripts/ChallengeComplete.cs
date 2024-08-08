using UnityEngine;

public class ChallengeComplete : MonoBehaviour
{
    void Update()
    {
        // Replace this condition with your own logic for challenge completion
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.Instance.OnChallengeComplete();
        }
    }
}
