using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PearlType
{
    normal,
    gold
}
public class Pearl : MonoBehaviour
{
    int _PearlScore;

    public PearlType _PearlType;


    private void Start()
    {
        switch (_PearlType)
        {
            case PearlType.normal:
                _PearlScore = 1;
                break;
            case PearlType.gold:
                _PearlScore = 5;
                break;
            default:
                break;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //ADD SCORE
            GameManagerDeepDive.instance.AddScore(_PearlScore);
            Destroy(gameObject);
        }
    }



}
