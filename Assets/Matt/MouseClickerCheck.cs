using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickerCheck : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click.
        {
            Debug.Log("Mouse Clicked");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Create a ray from the mouse pointer.
            RaycastHit hit;
            Debug.DrawLine(transform.position, transform.position + transform.forward * 100f, Color.red);
            if (Physics.Raycast(ray, out hit))
            {
                // The ray hit an object.
                GameObject clickedObject = hit.transform.gameObject;
                Debug.Log("Mouse clicked on " + clickedObject.name);

                // You can perform actions specific to the clicked object here.
            }
        }
    }
}
