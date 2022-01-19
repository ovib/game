using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBitController : MonoBehaviour
{

    public int minutes = 30;
    private TimeManager timeManager;

    private AudioSource myAudioSource;

    void Start(){
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        myAudioSource = GetComponentInParent<AudioSource>();
    }
     void OnTriggerEnter(Collider other){
        if(other.name == "Character"){
            myAudioSource.Play();
            timeManager.IncreaseDay(minutes);
             Destroy(transform.parent.gameObject);
        }
     }

}
