using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionButtonsManager : MonoBehaviour
{
    public TimeManager timeManager;
    public GameObject woodButton;
    public GameObject buildButton;
    public GameObject sleepButton;

    public GameObject character;

    private GameObject shelter;
    private ObstacleDetectorController obstacleDetectorController;
    private WoodButtonController woodButtonController;
    private BuildButtonController buildButtonController;
    private SleepButtonController sleepButtonController;
    private CharacterInsideShelterDetector characterInsideShelterDetector;

    private bool toSartNewDay = false;

    // Start is called before the first frame update
    void Start()
    {
        obstacleDetectorController = character.transform.GetChild(2).gameObject.GetComponent<ObstacleDetectorController>();
        characterInsideShelterDetector = character.GetComponent<CharacterInsideShelterDetector>();
        woodButtonController = woodButton.GetComponent<WoodButtonController>();
        buildButtonController = buildButton.GetComponent<BuildButtonController>();
        sleepButtonController = sleepButton.GetComponent<SleepButtonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(toSartNewDay){
            OnNewDay();
        }

        if(woodButtonController.limitReached)
        {
            woodButton.SetActive(false);
            buildButton.SetActive(true);

            if(obstacleDetectorController.currentlyInCollision)
            {
                buildButtonController.Disable();
            } else 
            {
                buildButtonController.Enable();
            }
        }

        if(buildButtonController.buildDone){
            buildButton.SetActive(false);
        }

        
        if(characterInsideShelterDetector.insideShelter && !sleepButtonController.sleepPressed){
            sleepButton.SetActive(true);
        } else if (sleepButtonController.sleepPressed){
            sleepButton.SetActive(false);
        }

    }

    public void OnNewDay(){
        Debug.Log("ON NEW DAY");
        
        if(!characterInsideShelterDetector.insideShelter){
            woodButtonController.Reset();
            woodButton.SetActive(true);
            Debug.Log("wood active");
            toSartNewDay = false;
        } else {
            toSartNewDay = true;
        }
    }
}
