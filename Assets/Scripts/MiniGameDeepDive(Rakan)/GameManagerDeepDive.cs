using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerDeepDive : MonoBehaviour
{
    const int _MAINSCENENUMBER = 0;
    public static GameManagerDeepDive instance {  get; private set; }
    float _pearlScore = 0;

    bool _lose = false;


    public void AddScore(float score)
    {
        _pearlScore += score;
    }

    public void GameOver()
    {
        if (_lose)
        {
            StartCoroutine(GameOverDelay());
        }
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(_MAINSCENENUMBER);
    }



    

    
}
