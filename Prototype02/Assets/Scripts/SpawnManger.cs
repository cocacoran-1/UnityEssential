using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    int spawnRangeX = 22;
    float spawnPosZ = 20;
    public float startDelay = 2f;
    public float spawnInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex],
            new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ),
            animalPrefabs[animalIndex].transform.rotation);
    }
}
