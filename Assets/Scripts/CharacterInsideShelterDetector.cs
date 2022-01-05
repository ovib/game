using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInsideShelterDetector : MonoBehaviour
{
    // [System.NonSerialized]
    public bool insideShelter = false;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Shelter Collider"){
            insideShelter = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.name == "Shelter Collider"){
            insideShelter = false;
        }
    }
}
