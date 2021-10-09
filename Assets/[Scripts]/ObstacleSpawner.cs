using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] bool spawnItem;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

    [SerializeField] GameObject obstaclePrefab;

    [SerializeField] List<GameObject> itemList;

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

        if (spawnItem)
        {
            int itemSpawnIndex = Random.Range(3, 6);

            if (itemSpawnIndex == obstacleSpawnIndex || itemSpawnIndex == obstacleSpawnIndex2)
            {
                while (itemSpawnIndex == obstacleSpawnIndex || itemSpawnIndex == obstacleSpawnIndex2)
                {
                    itemSpawnIndex = Random.Range(0, 6);
                }
            }

            Transform itemSpawn = transform.GetChild(itemSpawnIndex).transform;

            int itemIndex = Random.Range(0, 2);

            Instantiate(itemList[itemIndex], itemSpawn.position, itemList[itemIndex].transform.rotation);
        }

    }
}
