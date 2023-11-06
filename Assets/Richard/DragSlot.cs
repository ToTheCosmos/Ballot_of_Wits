using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSlot : MonoBehaviour
{
    public int CorrectAnswer;
    public TestingDrag draggedObject;
    public int Score;
    public ScoreTracking scoreupdater;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (draggedObject.Answer == CorrectAnswer)
            {
                Score += 1;
                Debug.Log(Score);
            }
            if (draggedObject != null)
            {
                scoreupdater.UpdateScore();
                CorrectAnswer += 1;
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        draggedObject = other.gameObject.GetComponent<TestingDrag>();
    }

    private void OnTriggerExit(Collider other)
    {
        draggedObject = null;
    }

    private void OnMouseUp()
    {
    }
}
