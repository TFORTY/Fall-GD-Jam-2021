using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] bool spawnItem;
    [SerializeField] bool spawnObstacles;
    [SerializeField] List<GameObject> obstacleList;
    [SerializeField] List<GameObject> itemList;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

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

        if (spawnObstacles)
        {
            if (obstacleSpawnIndex < 3)
            {
                Instantiate(obstacleList[0], spawnPoint.position, obstacleList[0].transform.rotation);
            }
            else
            {
                Instantiate(obstacleList[1], spawnPoint.position, obstacleList[1].transform.rotation);
            }

            if (obstacleSpawnIndex2 < 3)
            {
                Instantiate(obstacleList[0], spawnPoint2.position, obstacleList[0].transform.rotation);
            }
            else
            {
                Instantiate(obstacleList[1], spawnPoint2.position, obstacleList[1].transform.rotation);
            }
        }

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
