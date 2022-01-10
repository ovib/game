using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBitController : MonoBehaviour
{

    public int minutes = 30;
    public TimeManager timeManager;
    
    void OnTriggerEnter(Collider other){
        if(other.name == "Character"){
            timeManager.increaseDay(minutes);
             Destroy(transform.parent.gameObject);
        }
    }
}
