using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Save System made by rakan alhulail SIMPLE for game jam 2024
/// </summary>
public class SaveSystem : MonoBehaviour
{

    public static SaveSystem instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    //method

    public void SaveGame()
    {
        //Save
        PlayerPrefs.Save();
    }

    public void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public void SaveFloat(string key,int value)
    {
        PlayerPrefs.SetFloat(key,value);
    }

    


}
