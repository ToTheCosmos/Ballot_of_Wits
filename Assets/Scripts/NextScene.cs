using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NextScene : MonoBehaviour
{
    public float time = 15f;
    // Start is called before the first frame update
    public void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI timeLeft = this.GetComponent<TextMeshProUGUI>();
        time -= Time.deltaTime;
        timeLeft.text = time.ToString();
        if (time <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Switched Scene");
        }
    }
}
