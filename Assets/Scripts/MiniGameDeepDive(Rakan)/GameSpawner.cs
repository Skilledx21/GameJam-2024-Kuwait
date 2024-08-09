using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    public GameObject pearlPrefab; 
    public GameObject fishPrefab; 

    public Vector2 boxCenter; 
    public Vector2 boxSize; 

    public int numberOfPearls = 5; 
    public int numberOfFishesPerPearl = 1; 

    void Start()
    {
        SpawnPearlsAndFishes();
    }

    void SpawnPearlsAndFishes()
    {
        for (int i = 0; i < numberOfPearls; i++)
        {
           
            Vector2 pearlPosition = new Vector2(
                Random.Range(boxCenter.x - boxSize.x / 2, boxCenter.x + boxSize.x / 2),
                Random.Range(boxCenter.y - boxSize.y / 2, boxCenter.y + boxSize.y / 2)
            );

           
            GameObject pearl = Instantiate(pearlPrefab, pearlPosition, Quaternion.identity);

            // Spawn fishes near the pearl
            for (int j = 0; j < numberOfFishesPerPearl; j++)
            {
                Vector2 fishPosition = pearlPosition + new Vector2(
                    Random.Range(-1.0f, 1.0f), 
                    Random.Range(-1.0f, 1.0f)
                );

                
                fishPosition.x = Mathf.Clamp(fishPosition.x, boxCenter.x - boxSize.x / 2, boxCenter.x + boxSize.x / 2);
                fishPosition.y = Mathf.Clamp(fishPosition.y, boxCenter.y - boxSize.y / 2, boxCenter.y + boxSize.y / 2);

                
                
                Instantiate(fishPrefab, fishPosition, Quaternion.identity);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boxCenter, boxSize);
    }
}
