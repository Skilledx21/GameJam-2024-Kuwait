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
        _pearlsNeed = 7;
        _Won = false;

    }


    private void Update()
    {
        if (!DeepDiveUI.Instance.isStarted) return;
        if (_pearlsNeed <= 0)
        {
            //WON
            WinGame();
        }


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
    }

    IEnumerator GameWin()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(_MAINSCENENUMBER);
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(_MAINMENUNUMBER);
    }



    

    
}
