using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DeathPanelController : MonoBehaviour
{
    private TextMeshProUGUI newBestLabel;
    private TextMeshProUGUI previousBestLabel;
    private TextMeshProUGUI currentScoreText;

    private bool newBest = false;

    private TimeSpan score;
    private TimeSpan bestScore;

    
    // Start is called before the first frame update
    void Awake()
    {
        newBestLabel = gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        currentScoreText = gameObject.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>();
        previousBestLabel = gameObject.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>();
    }

     void OnEnable()
    {
        if(newBest){
            Debug.Log("NEW BEST! " + score);
            newBestLabel.gameObject.SetActive(true);
            previousBestLabel.gameObject.SetActive(false);
            currentScoreText.text = ScoreText(score);

        } else {
            newBestLabel.gameObject.SetActive(false);
            previousBestLabel.gameObject.SetActive(true);
            currentScoreText.text = ScoreText(score);
            previousBestLabel.text = "Best: " + ScoreText(bestScore);
        }
    }

    public void SetScoreUI(TimeSpan score, TimeSpan bestScore){
        newBest = false;
        this.score = score;
        this.bestScore = bestScore;

    }
    
    public void SetBestScoreUI(TimeSpan newScore){
        Debug.Log("SET BEST: " + newScore);
        newBest = true;
        this.score = newScore;
    }


    private String ScoreText(TimeSpan score){
        return score.Days + " days " + score.Hours + " hours " + score.Minutes + " minutes";
    }
}
