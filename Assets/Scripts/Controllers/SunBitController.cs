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

}
