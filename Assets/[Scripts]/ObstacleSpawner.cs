using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] bool spawnCoffee;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

    public GameObject obstaclePrefab;
    public GameObject coffeePrefab;

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(0, 6);
        int obstacleSpawnIndex2 = Random.Range(0, 6);

        if (obstacleSpawnIndex == obstacleSpawnIndex2)
        {
            while(obstacleSpawnIndex2 == obstacleSpawnIndex)
            {
                obstacleSpawnIndex2 = Random.Range(0, 6);
            }
        }

        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Transform spawnPoint2 = transform.GetChild(obstacleSpawnIndex2).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, obstaclePrefab.transform.rotation);
        Instantiate(obstaclePrefab, spawnPoint2.position, obstaclePrefab.transform.rotation);

        if (spawnCoffee)
        {
            int coffeeSpawnIndex = Random.Range(3, 6);

            if (coffeeSpawnIndex == obstacleSpawnIndex || coffeeSpawnIndex == obstacleSpawnIndex2)
            {
                while (coffeeSpawnIndex == obstacleSpawnIndex || coffeeSpawnIndex == obstacleSpawnIndex2)
                {
                    coffeeSpawnIndex = Random.Range(0, 6);
                }
            }

            Transform coffeSpawn = transform.GetChild(coffeeSpawnIndex).transform;
            Instantiate(coffeePrefab, coffeSpawn.position, coffeePrefab.transform.rotation);
        }

    }
}
