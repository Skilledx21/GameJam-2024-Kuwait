using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSway : MonoBehaviour
{  
    [SerializeField] private float rotationAmount = 5f;
    [SerializeField] private float rotationSpeed = 1f;    


    

    private PlayerControllerShip playerController;
    void Start()
    {
             
        playerController = GetComponent<PlayerControllerShip>();

    }

    void Update()
    {
        if (!playerController.isMoving)
        {
            

            // Sway rotation back and forth
            float swayRotation = Mathf.Sin(Time.time * rotationSpeed) * rotationAmount;

            // Apply the new position and rotation
           
            transform.rotation = Quaternion.Euler(0, 0, swayRotation);
        }
        
        
    }
}
