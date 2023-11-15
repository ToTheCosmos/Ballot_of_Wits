using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerForNext : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI countdown;
    public Collider player;
    public Rigidbody rb;
    public GameObject button;

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            Destroy(rb);
            player.enabled = false;
            button.SetActive(true);
        }
        else
        {
            timer -= Time.deltaTime;
            int timeLeft = (int)Mathf.Round(timer);
            countdown.text = timeLeft.ToString();
        }
    }
}
