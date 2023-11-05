using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterSpawn : MonoBehaviour
{
    public float timeSeconds;
    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeSeconds = Random.Range(2, 8);
    }

    // Update is called once per frame
    void Update()
    {
        // Ticks down the timer by 1 for every frame
        timeSeconds -= Time.deltaTime;
        Spawn();
    }

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
        timeSeconds = Random.Range(2, 8);
    }

    void SpawnObject()
    {
        GameObject newObject = Instantiate(objectToSpawn);
        newObject.transform.localPosition = new Vector3(17.5959f, 1.525595f, -6.880136f);
    }
}
