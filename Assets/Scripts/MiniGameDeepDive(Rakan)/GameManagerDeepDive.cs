using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerDeepDive : MonoBehaviour
{
    const int _MAINSCENENUMBER = 0;
    public static GameManagerDeepDive instance {  get; private set; }
    private void Awake()
    {
        instance = this;
    }
    int _pearlScore = 0;

    public bool _lose = false;


    public void AddScore(int score)
    {
        _lose = false;
        _pearlScore += score;
    }

    public void GameOver()
    {
        SaveSystem.instance.SaveInt("Pearl", _pearlScore);
        _lose = true;
        StartCoroutine(GameOverDelay());
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(_MAINSCENENUMBER);
    }



    

    
}
