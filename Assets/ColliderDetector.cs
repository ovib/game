using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    // [System.NonSerialized]
    public bool insideShelter = false;

    void OnTriggerEnter(Collider other){
        insideShelter = true;
        // Debug.Log("character inside shelter" + other.gameObject.name);
    }

    void OnTriggerExit(Collider other){
        insideShelter = false;
        // Debug.Log(gameObject.name + "character outside shelter" + other.gameObject.name);
    }
}
