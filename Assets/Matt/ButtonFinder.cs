using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFinder : MonoBehaviour
{
    private void Start()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag(" Button");
        foreach (GameObject i in buttons)
        {
            Debug.Log(i);
        }
    }

    private void OnButtonClicked(GameObject clickedButton)
    {
        Debug.Log(clickedButton);
    }
}
