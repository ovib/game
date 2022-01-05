using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionButtonsManager : MonoBehaviour
{
    public TimeController timeController;
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
        if(woodButtonController.LimitReached)
        {
            woodButton.SetActive(false);
            buildButton.SetActive(true);

            if(obstacleDetectorController.currentlyInCollision)
            {
                buildButtonController.Disable();
            } else 
            {
                buildButtonController.Enable(character);
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
}
