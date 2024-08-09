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

    float exclusionRadius;

    void Start()
    {
        exclusionRadius = 10f;
        SpawnPearlsAndFishes();
    }

    void SpawnPearlsAndFishes()
    {
        for (int i = 0; i < numberOfPearls; i++)
        {
            Vector2 pearlPosition = GenerateRandomPosition();

            // Instantiate the pearl at the calculated position
            GameObject pearl = Instantiate(pearlPrefab, pearlPosition, Quaternion.identity);

            // Spawn fishes near the pearl
            for (int j = 0; j < numberOfFishesPerPearl; j++)
            {
                Vector2 fishPosition = pearlPosition + new Vector2(
                    Random.Range(-1.0f, 1.0f), // Adjust these values to control how far the fish can be from the pearl
                    Random.Range(-1.0f, 1.0f)
                );

                // Ensure the fish stays within the box boundaries
                fishPosition.x = Mathf.Clamp(fishPosition.x, boxCenter.x - boxSize.x / 2, boxCenter.x + boxSize.x / 2);
                fishPosition.y = Mathf.Clamp(fishPosition.y, boxCenter.y - boxSize.y / 2, boxCenter.y + boxSize.y / 2);

                // Instantiate the fish at the calculated position
                Instantiate(fishPrefab, fishPosition, Quaternion.identity);
            }
        }
    }

    Vector2 GenerateRandomPosition()
    {
        Vector2 position;
        do
        {
            position = new Vector2(
                Random.Range(boxCenter.x - boxSize.x / 2, boxCenter.x + boxSize.x / 2),
                Random.Range(boxCenter.y - boxSize.y / 2, boxCenter.y + boxSize.y / 2)
            );
        }
        while (Vector2.Distance(position, boxCenter) < exclusionRadius);

        return position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boxCenter, boxSize);
    }
}
