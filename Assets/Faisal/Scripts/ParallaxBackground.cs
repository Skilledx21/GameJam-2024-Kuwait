using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    [SerializeField] private float parallaxEffectMultiplier = 0.5f;
    public Transform playerTransform;
    private Vector3 lastPlayerPosition;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        lastPlayerPosition = playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 transformposition = transform.position;
        float deltamovement = playerTransform.position.x - lastPlayerPosition.x;
        
        transformposition.x -= deltamovement * parallaxEffectMultiplier;
        transform.position = transformposition;
        lastPlayerPosition = playerTransform.position;

    }
}
