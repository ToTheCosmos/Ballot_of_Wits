using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirSpawn : MonoBehaviour
{
    public float timeSeconds;
    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeSeconds = Random.Range(3, 8);
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
            SpawnObject();
            TimerEnded();
        }
    }

    // Reset timer
    private void TimerEnded()
    {
        timeSeconds = Random.Range(3, 8);
    }

    // Spawns a seperate instance of the prefab
    void SpawnObject()
    {
        GameObject newObject = Instantiate(objectToSpawn);
        newObject.transform.localPosition = new Vector3(12.67f, 6.48f, -5.81f);
    }
}
