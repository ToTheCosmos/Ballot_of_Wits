using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicTextbox : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private string PlayerOption;
    public string InteractiveString = "-";
    public GameObject PolicyButton;

    [TextArea(3, 10)]
    public string[] lines;
    public float textSpeed;
    public bool Waiting = false;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
        }
    }

    void StartDialogue()
    {
        //Sets Index to 0 to start text
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //Types out each individual letter
        //Need to make game wait for player to click an option
        //If waiting for a response, stop typing
        //When response is clicked, add it to current text line.
        //Continue typing
        foreach (char c in lines[index].ToCharArray())
        {
            if (Waiting == false)
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
                if (c == InteractiveString[0])
                {
                    Waiting = true;
                }
            }
            else
            {
                PolicyButton.SetActive(true);
            }
        }
    }

    void NextLine()
    {
        //Moves to next line
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}