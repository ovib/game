using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public ColliderDetector colliderDetector;
    public TimeController timeController;
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
        if(timeController.isNight && !colliderDetector.insideShelter){
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
