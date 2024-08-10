using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerasc : MonoBehaviour
{
    public int cameraIndex;


    private void Awake()
    {
        switch (cameraIndex)
        {
            case 1:
                GameManager.Instance.camera1 = this.gameObject;
                break;

            case 2:
                GameManager.Instance.camera2 = this.gameObject;
                break;
            default:
                break;
        }
    }
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
