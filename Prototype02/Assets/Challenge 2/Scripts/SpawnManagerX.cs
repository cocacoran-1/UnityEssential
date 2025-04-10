using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 2.0f;

    float timeBetweenSpawns = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        timeBetweenSpawns -= Time.deltaTime;
        if (timeBetweenSpawns < 0)
        {
            timeBetweenSpawns = Random.Range(2f, 4f);
            InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
        }
    }
    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        int randomIndex = Random.Range(0, ballPrefabs.Length);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomIndex], spawnPos, ballPrefabs[randomIndex].transform.rotation);
    }

}
