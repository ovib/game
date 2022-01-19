using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelController : MonoBehaviour
{
    public TimeManager timeManager;
    public ThirdPersonInput input;
    public GameObject inGameUI;
    public GameObject text;
    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if(!gameStarted && (input.verticalMovement != 0 || input.horizontalMovement != 0)){
           timeManager.StartTime();
           inGameUI.SetActive(true);
           text.SetActive(false);
       } 

    }
}
