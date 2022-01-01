using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBitController : MonoBehaviour
{

    public int minutes = 30;
    public TimeController timeController;
    
    void OnTriggerEnter(Collider other){
        if(other.name == "Character"){
            timeController.increaseDay(minutes);
             Destroy(transform.parent.gameObject);
        }
    }
}
