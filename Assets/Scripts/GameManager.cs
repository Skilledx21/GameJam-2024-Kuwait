using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float slowMoDuration;  // Duration of the slow motion effect
    private bool isSlowMoActive = false;  // Flag to check if slow motion is active
    private float originalFixedDeltaTime;  // To store the original fixedDeltaTime

    public Transform _QuestionTeleportArea;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Ensure the GameManager persists across scenes
        }
        else
        {
            Destroy(gameObject);  // Ensure only one instance exists
        }
    }

    private void Start()
    {
        originalFixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (isSlowMoActive)
        {
            slowMoDuration -= Time.unscaledDeltaTime;
            if (slowMoDuration <= 0f)
            {
                StopSlowMotion();
            }
        }
    }

    public void StartSlowMotion()
    {
        isSlowMoActive = true;
        Time.timeScale = 0.1f;  // Change this value for different slow motion effects
        Time.fixedDeltaTime = originalFixedDeltaTime * Time.timeScale;
    }

    public void StopSlowMotion()
    {
        isSlowMoActive = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = originalFixedDeltaTime;
    }


    public void OnChallengeComplete()
    {
        StopSlowMotion();
        // Add any other logic to handle challenge completion
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
