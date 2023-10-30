using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFinder : MonoBehaviour
{
    private void Start()
    {
        Button[] buttons = FindObjectsOfType<Button>();

    }

    private void OnButtonClicked(Button clickedButton)
    {
        Debug.Log(clickedButton);
    }
}
