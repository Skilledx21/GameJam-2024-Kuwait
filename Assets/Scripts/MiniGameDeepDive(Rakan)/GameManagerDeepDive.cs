using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerDeepDive : MonoBehaviour
{
    const int _MAINSCENENUMBER = 1;
    const int _MAINMENUNUMBER = 0;

    [SerializeField]float timer = 60f;

    public int _pearlsNeed;

    public int _pearlScore = 0;

    public bool _lose = false;
    public bool _Won;


    public static GameManagerDeepDive instance {  get; private set; }
    private void Awake()
    {
        instance = this;
    }



    private void Start()
    {
        _pearlsNeed = 3;
        _Won = false;

    }


    private void Update()
    {
        if (!DeepDiveUI.Instance.isStarted) return;
        


        if (_Won) return;

        //timer
        if (timer < 0)
        {
            //GAME OVER
            DeepDiveUI.Instance.LosePanel();

        } else
        {
            timer -= Time.deltaTime;
        }


    }


    public void AddScore(int score)
    {
        _lose = false;
        _pearlScore += score;
        _pearlsNeed--;

        if (_pearlScore >= 3)
        {
            WinGame();
        }
    }

    public void GameOver()
    {
        _lose = true;
        StartCoroutine(GameOverDelay());
    }

    public void WinGame()
    {
        //DO SOMTHING GO BACK
        _Won = true;
        GameManager.Instance.keysGained++;
        GameManager.Instance.challenge3complete = true;
        SceneManager.LoadScene("MainGame");
    }

 
    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(2);
        GameManager.Instance.RestartGame();
        
    }



    

    
}
