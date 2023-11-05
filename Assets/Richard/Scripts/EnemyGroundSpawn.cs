using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundSpawn : MonoBehaviour
{
    public float timeSeconds;
    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeSeconds = Random.Range(1, 8);
    }

    // Update is called once per frame
    void Update()
    {
        // Ticks down the timer by 1 for every frame
        timeSeconds -= Time.deltaTime;
        Spawn();
    }

    // Spawn method to start and reset a timer
    // When timer ends, spawn an instance of a grounded enemy
    private void Spawn()
    {
        if (timeSeconds <= 0)
        {
            TimerEnded();
            SpawnObject();
        }
    }
    
    // Reset timer
    private void TimerEnded()
    {
        timeSeconds = Random.Range(1, 8);
    }

    // Spawns a seperate instance of the prefab
    void SpawnObject()
    {
        GameObject newObject = Instantiate(objectToSpawn);
        newObject.transform.position = new Vector3(20.03f, 0.76f, -5.37f);
    }
}
