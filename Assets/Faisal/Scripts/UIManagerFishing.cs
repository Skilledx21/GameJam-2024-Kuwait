using ArabicSupport;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerFishing : MonoBehaviour
{
    public static UIManagerFishing Instance { get; private set; }

    public Text CaughtFishText;
    private int FishCaught;
    public Text Timelimit;
    public Text hint;
    [SerializeField] private int FishNeeded = 10;
    private float timeRemaining = 60f;
    private bool timerIsRunning = false;
    public AudioSource OceanSound;
    [SerializeField] private GameObject HintPanel;
    [SerializeField] private Text ContinueText;
    [SerializeField] private Text TimeremainingText;
    [SerializeField] private Text FishCaughtText;
    public bool gameStarted = false;
    private void Awake()
    {
        
        if (Instance == null)
        {
            
            Instance = this;
            
        }
    }

    private void Start()
    {
        hint.text = ArabicFixer.Fix(hint.text);
        ContinueText.text = ArabicFixer.Fix(ContinueText.text);
        TimeremainingText.text = ArabicFixer.Fix(TimeremainingText.text);
        FishCaughtText.text = ArabicFixer.Fix(FishCaughtText.text);
        Time.timeScale = 0f;
        timerIsRunning = true;
        UpdateTimeDisplay();
    }
    public void IncreaseFishAmount (int amount)
    {
        FishCaught += amount;
        CaughtFishText.text = FishCaught.ToString();
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimeDisplay();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                EndGame();
            }
        }
    }

    private void UpdateTimeDisplay()
    {
        Timelimit.text = Mathf.RoundToInt(timeRemaining).ToString();
    }

    private void EndGame()
    {
        if (FishCaught >= FishNeeded)
        {
            Debug.Log("You Won!");
        }
        else
        {
            Debug.Log("You Lost");
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        HintPanel.SetActive(false);
        gameStarted = true;
        OceanSound.Play();
    }
}
