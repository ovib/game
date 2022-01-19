using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public CharacterInsideShelterDetector characterInsideShelterDetector;
    public DeathPanelController deathPanelController;
    public TimeManager timeManager;
    public Canvas canvas;
    private GameObject deathPanel;
    private GameObject gamePanel;

    private DateTime startingDateTime;
    private static TimeSpan bestScore;
    private TimeSpan currentScore;
    public TextMeshProUGUI scoreText;

    private static int sceneCount = 0;

    void Start()
    {
        gamePanel = canvas.transform.GetChild(0).gameObject;
        deathPanel = canvas.transform.GetChild(1).gameObject;
        startingDateTime = DateTime.Now.Date + TimeSpan.FromHours(timeManager.startHour);
        currentScore = TimeSpan.Zero;
        
        // TO DO: read best score from local memory

        if(sceneCount == 0){
            bestScore = TimeSpan.Zero;
        }

        sceneCount++;
    }

    void Update()
    {
        if(timeManager.isNight && !characterInsideShelterDetector.insideShelter){
            OnDeath();
        } else {
            UpdateScore();
        }
    }

    public void OnRetry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDeath(){
        if(currentScore > bestScore){
            bestScore = currentScore;
            deathPanelController.SetBestScoreUI(bestScore);
        } else{
            deathPanelController.SetScoreUI(currentScore, bestScore);
        }

        gamePanel.gameObject.SetActive(false);
        deathPanel.gameObject.SetActive(true);
    }

    private void UpdateScore(){
        currentScore = timeManager.currentTime - startingDateTime;
        if(scoreText.text != null) scoreText.text = UpdatedScoreText(currentScore);
    }

    private String UpdatedScoreText(TimeSpan score){
         String d = score.Days.ToString();
         String h = score.Hours.ToString();
         String m = score.Minutes.ToString();

         if (d.Length < 2) d = "0" + d;
         if (h.Length < 2) h = "0" + h;
         if (m.Length < 2) m = "0" + m;
        return d + "d " + h + "h " + m + "m";
    }

}
