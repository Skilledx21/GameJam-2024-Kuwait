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

    [SerializeField] private int FishNeeded = 5;
    private float timeRemaining = 60f;
    private bool timerIsRunning = false;
    private void Awake()
    {
        
        if (Instance == null)
        {
            
            Instance = this;
            
        }
    }

    private void Start()
    {
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
}
