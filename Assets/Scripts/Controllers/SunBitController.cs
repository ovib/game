using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBitController : MonoBehaviour
{

    public int minutes = 30;
    private TimeManager timeManager;

    void Start(){
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }
    
    void OnTriggerEnter(Collider other){
        if(other.name == "Character"){
            timeManager.increaseDay(minutes);
             Destroy(transform.parent.gameObject);
        } else{
            Debug.Log("Altro oggetto! nome: " + other);
        }
    }

    // private void OnCollisionStay(Collision collision){
    //     Debug.LogFormat("{0} collision stay: {1}", this, collision.gameObject);
    // }

}
