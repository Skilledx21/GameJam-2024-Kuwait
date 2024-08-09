using UnityEngine;

public class ChallengeComplete : MonoBehaviour
{
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.Instance.OnChallengeComplete();
        }
    }
}
