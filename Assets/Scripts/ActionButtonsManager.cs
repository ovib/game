using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonsManager : MonoBehaviour
{
    public GameObject woodButton;
    public GameObject buildButton;
    private WoodButtonController woodButtonController;

    // Start is called before the first frame update
    void Start()
    {
        woodButtonController = woodButton.GetComponent<WoodButtonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(woodButtonController.LimitReached){
            woodButton.SetActive(false);
            buildButton.SetActive(true);
        }
    }
}
