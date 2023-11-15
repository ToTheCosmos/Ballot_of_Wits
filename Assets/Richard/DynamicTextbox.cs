using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicTextbox : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private string PlayerOption;
    public string pause = "-";
    public GameObject dragslot;
    public List<GameObject> PaulHands;
    public List<GameObject> JackyHands;
    public int PaulIndex = 0;
    public int JackyIndex = 0;
    public GameObject Paul;
    public GameObject Jacky;
    float height = 0.5f;
    float speed = 5f;
    public DragSlot scoretracker;
    public GameObject JackyWin;
    public GameObject PaulWin;

    [TextArea(3, 10)]
    public string[] lines;
    public float textSpeed;

    private int index;
    private string talking;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        talking = lines[index+1];
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
            if (dragslot.active == false)
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
                if(c==pause[0])
                {
                    dragslot.SetActive(true);
                }
            }
        }

    }

    void NextLine()
    {
        //Moves to next line
        if ((index < lines.Length-1) & (dragslot.active==false))
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            if (talking[0].ToString() == "P")
            {
                PaulHands[PaulIndex].SetActive(false);
                PaulIndex += 1;
                if (PaulIndex > 3)
                {
                    PaulIndex = 0;
                }
                PaulHands[PaulIndex].SetActive(true);
            }
            else if (talking[0].ToString() == "J")
            {
                JackyHands[JackyIndex].SetActive(false);
                JackyIndex += 1;
                if (JackyIndex > 3)
                {
                    JackyIndex = 0;
                }
                JackyHands[JackyIndex].SetActive(true);
            }
            else
            {
                JackyHands[JackyIndex].SetActive(false);
                PaulHands[PaulIndex].SetActive(false);
                JackyIndex = 0;
                PaulIndex = 0;
                JackyHands[JackyIndex].SetActive(true);
                PaulHands[PaulIndex].SetActive(true);

            }
        }
        if (index >= lines.Length-1)
        {
            if (scoretracker.Score >= 270)
            {
                JackyWin.SetActive(true);
            }
            else
            {
                PaulWin.SetActive(true);
            }
        }
    }
}