using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float slowMoDuration;  //Duration of the slow motion effect
    private bool isSlowMoActive = false;  //check if slow motion is active
    private float originalFixedDeltaTime;  //To store the original fixedDeltaTime

    //Timer 
    float gameTime;

    //OVER
    bool _gameOver;


    public Transform _QuestionTeleportArea;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);  
        }
    }

    private void Start()
    {
        gameTime = 0;
        _gameOver = false;
        originalFixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (_gameOver) return;


        //Start timing
        gameTime += Time.deltaTime;


        //slow mo effect ..
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
        //StopSlowMotion();
       
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
