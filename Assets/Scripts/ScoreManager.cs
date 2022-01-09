using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public CharacterInsideShelterDetector characterInsideShelterDetector;
    public TimeManager timeManager;
    public Canvas canvas;
    private GameObject deathPanel;
    private GameObject gamePanel;

    // Start is called before the first frame update
    void Start()
    {
        gamePanel = canvas.transform.GetChild(0).gameObject;
        deathPanel = canvas.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeManager.isNight && !characterInsideShelterDetector.insideShelter){
            OnDeath();
        }
    }

    public void OnRetry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDeath(){
        gamePanel.gameObject.SetActive(false);
        deathPanel.gameObject.SetActive(true);
    }
}
