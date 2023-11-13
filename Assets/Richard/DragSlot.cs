using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSlot : MonoBehaviour
{
    public int CorrectAnswer;
    public TestingDrag draggedObject;
    public int Score;
    public ScoreTracking scoreupdater;
    public List<GameObject> AnswerCategories;
    private int listIndex = 0;
    public int TotalAnswers;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (draggedObject.Answer == CorrectAnswer)
            {
                Score += draggedObject.AnswerWorth;
                Debug.Log(Score);
            }
            if (draggedObject != null)
            {
                scoreupdater.UpdateScore();
                CorrectAnswer += 1;
                TotalAnswers += 2;
                if (CorrectAnswer > 2)
                {
                    AnswerCategories[listIndex].SetActive(false);
                    listIndex += 1;
                    AnswerCategories[listIndex].SetActive(true);
                    CorrectAnswer = 1;
                }
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
}
