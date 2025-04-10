using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    Vector3 spawnPos = new Vector3(30, 0, 0);
    int objectIndex;
    float startDelay = 2;
    float repeatRate = 2;
    PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript =
            GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            objectIndex = Random.Range(0, objectPrefabs.Length);
            Instantiate(objectPrefabs[objectIndex],
                spawnPos, objectPrefabs[objectIndex].transform.rotation);
        }
    }
}
