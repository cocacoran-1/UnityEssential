using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float timeBetweenSpawns = 1.0f;
    // Update is called once per frame
    void Update()
    {
        timeBetweenSpawns -= Time.deltaTime;
        if (timeBetweenSpawns < 0)
        {
            timeBetweenSpawns = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timeBetweenSpawns = 1.0f;
            }
        }
        
    }
}
