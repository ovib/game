using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterController : MonoBehaviour
{
  public GameObject character;
  public CharacterInsideShelterDetector characterInsideShelterDetector;
  public GameObject shelterPrefab;
  private GameObject shelter;
  public GameObject destroyableShelterPrefab;
  private GameObject destroyableShelter;
  private Vector3 position;
  private bool toBeDestroyed = false;
  private bool destroyed = false;


  void Update(){
    if(toBeDestroyed && !destroyed && !characterInsideShelterDetector.insideShelter){
      DestroyShelter();
     }
  }
  public void CreateShelter(){
    position = character.transform.GetChild(2).position;
    shelter = Instantiate(shelterPrefab, position, Quaternion.identity);
  }

  public void DestroyShelter(){
    // destroy only if character is oustside shelter
    if(!characterInsideShelterDetector.insideShelter){ 
      Destroy(shelter);
      destroyableShelter = Instantiate(destroyableShelterPrefab, position, Quaternion.identity);
      StartCoroutine(DestroyShelterCoroutine());
      destroyed = true;
    }
    // activate flag, the new check is done in the Update()
    // when character will come out, shelter will be destroyed
    toBeDestroyed = true;
  }

  private IEnumerator DestroyShelterCoroutine(){
     yield return new WaitForSeconds(4f);
     for(int i = 0; i < destroyableShelter.transform.childCount; i++){
       destroyableShelter.transform.GetChild(i).GetComponent<Rigidbody>().drag = 6; // slow down object
       Destroy(destroyableShelter.transform.GetChild(i).GetComponent<MeshCollider>()); // make it fall through the plane 
     }
  }

  public void Reset(){
    destroyed = false;
  }

}
