using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject powerupPrefabs;
    public float spawnRangeX = 14;
    public float spawnRangeZ = 7;
    public int waveCount = 1;
    public int enemyCount;
    public int enemySpawnDelay = 2;
    public int enemySpawnInterval = 2;
    public int powerupSpawnDelay = 5;
    public int powerupSpawnInterval = 5;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", enemySpawnDelay, enemySpawnInterval);
        InvokeRepeating("SpawnPowerup", powerupSpawnDelay, powerupSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[randomIndex], RandomPositionX()+ new Vector3(0,0,7) , 
            enemyPrefab[randomIndex].transform.rotation);
    }
    void SpawnPowerup()
    {
        Instantiate(powerupPrefabs, GenerateSpawnPosition(), powerupPrefabs.transform.rotation);
    }
    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    Vector3 RandomPositionX()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 randomPosX = new Vector3(spawnPosX, 0, 0);
        return randomPosX;
    }
}
