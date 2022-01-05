using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetectorController : MonoBehaviour
{
    public bool currentlyInCollision = false;

    void OnTriggerEnter(Collider other){
        currentlyInCollision = true;
    }

    void OnTriggerExit(Collider other){
        currentlyInCollision = false;
    }
}
