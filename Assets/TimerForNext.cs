using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerForNext : MonoBehaviour
{
    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
