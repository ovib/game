using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodStickController : MonoBehaviour
{
    [System.NonSerialized]
    public WoodButtonController woodButtonController;

    void OnTriggerEnter(Collider other){
        if(other.name == "Character" && !woodButtonController.limitReached){
            woodButtonController.UpdateButton();
            Destroy(transform.gameObject);
        }
    }
    
}