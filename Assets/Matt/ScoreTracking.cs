using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracking : MonoBehaviour
{
    public DragSlot scoretracker;
    // Start is called before the first frame update

    public void UpdateScore()
    {
        TextMeshProUGUI scoretext = this.GetComponent<TextMeshProUGUI>();
        scoretext.text = "Electoral Votes: " + scoretracker.Score + "/" + "538. " + (538-scoretracker.Score) + " more needed for a majority!";
    }
}
