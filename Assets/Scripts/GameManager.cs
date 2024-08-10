using UnityEngine;
using UnityEngine.SceneManagement;
using ArabicSupport;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float slowMoDuration;  //Duration of the slow motion effect
    private bool isSlowMoActive = false;  //check if slow motion is active
    private float originalFixedDeltaTime;  //To store the original fixedDeltaTime

    public int keyNeeded = 3;
    public int keysGained;
    [SerializeField] public GameObject camera1;
    [SerializeField] public GameObject camera2;

    public int challengeNum;
    public bool canTravel;
    //Timer 
    float gameTime;

    //OVER
    bool _gameOver;

    public bool challenge1complete;
    public bool challenge2complete;
    public bool challenge3complete;
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

        Debug.Log(keysGained);

        
        camera1.SetActive(true);
        camera2.SetActive(false);
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

        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Keys Gained " + keysGained);
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
        keysGained = 0;
        gameTime = 0;
        _gameOver = false;
        challenge1complete = false;
        challenge2complete = false;
        challenge3complete = false;
        SceneManager.LoadScene("MainGame");
    }

    public void SwitchCamera()
    {
        if (camera1.activeSelf)

        {
            camera2.SetActive(true);
            camera1.SetActive(false);
        }
        else
        {
            camera2.SetActive(false);
            camera1.SetActive(true);
        }
        
    }

}
