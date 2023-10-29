using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFinder : MonoBehaviour
{
    private void Start()
    {
        // Find all Button components in the scene
        Button[] buttons = FindObjectsOfType<Button>();

        // Add an onClick event listener to each button
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClicked(button));
        }
    }

    private void OnButtonClicked(Button clickedButton)
    {
        // This method will be called when any button in the scene is clicked.
        Debug.Log("Button clicked: " + clickedButton.name);
        // You can add your logic here based on which button was clicked.
    }
}
