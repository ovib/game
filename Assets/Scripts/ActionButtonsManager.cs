using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonsManager : MonoBehaviour
{
    public GameObject woodButton;
    public GameObject buildButton;

    public GameObject character;

    private GameObject shelter;
    private ObstacleDetectorController obstacleDetectorController;
    private WoodButtonController woodButtonController;
    private BuildButtonController buildButtonController;

    // Start is called before the first frame update
    void Start()
    {
        obstacleDetectorController = character.transform.GetChild(2).gameObject.GetComponent<ObstacleDetectorController>();
        woodButtonController = woodButton.GetComponent<WoodButtonController>();
        buildButtonController = buildButton.GetComponent<BuildButtonController>();
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

    }
}
