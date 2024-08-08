using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerFishing : MonoBehaviour
{
    public static UIManagerFishing Instance { get; private set; }

    public Text CaughtFishText;
    private int CaughtFish;

    private void Awake()
    {
        
        if (Instance == null)
        {
            
            Instance = this;
            
        }
    }
    public void IncreaseFishAmount (int amount)
    {
        CaughtFish += amount;
        CaughtFishText.text = CaughtFish.ToString();
    }
}
