using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScoreDisplay : MonoBehaviour
{
    public TMP_Text lastScoreText; 

    void Start()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        lastScoreText.text = "Last Score: " + lastScore.ToString();
    }
}
