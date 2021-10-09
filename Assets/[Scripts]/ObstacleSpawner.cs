using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(0, 3);
        int obstacleSpawnIndex2 = Random.Range(0, 3);

        if (obstacleSpawnIndex == obstacleSpawnIndex2)
        {
            while(obstacleSpawnIndex2 == obstacleSpawnIndex)
            {
                obstacleSpawnIndex2 = Random.Range(0, 3);
            }
        }

        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Transform spawnPoint2 = transform.GetChild(obstacleSpawnIndex2).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
        Instantiate(obstaclePrefab, spawnPoint2.position, Quaternion.identity, transform);
    }
}
