using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreHandler : MonoBehaviour
{
    public float Score;
    public TMP_Text scoreText; // Assign in Inspector

    void Update()
    {
        Score += Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(Score).ToString();
    }

    public void SaveLastScore()
    {
        PlayerPrefs.SetInt("LastScore", Mathf.FloorToInt(Score));
    }




}
