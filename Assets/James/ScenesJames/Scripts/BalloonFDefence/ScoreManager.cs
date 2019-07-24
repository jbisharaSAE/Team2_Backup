using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int pointsAdded;
    private float currentPoints;
    private bool addingScore = false;

    public float speed = 10f;
    public float progressRatio;
    public float progressScore;
    public int playerScoreDisplay;
    
    
    public Image progressBar;

    // Update is called once per frame
    void Update()
    {
        
        //scoreDisplayText.text = playerScoreDisplay.ToString();

        progressRatio = progressScore / 100f;

        progressBar.fillAmount = progressRatio;

        if (addingScore)
        {
            if (progressScore <= pointsAdded)
            {
                progressScore += speed * Time.deltaTime;
            }
            else
            {
                if(pointsAdded == 100)
                {
                    pointsAdded = 0;
                }
                addingScore = false;
            }
                
        }
    }

    public void UpdateScore(int points)
    {
        playerScoreDisplay += points;
        addingScore = true;
        pointsAdded += points;

    }
}
