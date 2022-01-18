using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSticksGenerator : MonoBehaviour
{
    public GameObject WoodStickPrefab;
    public int num = 5;
    public float minPosX = -88;
    public float maxPosX = 90;
    public float minPosZ = -70;
    public float maxPosZ = 74;
    public float posY = 0.18f;

    public int capsuleHeight = 5;

    private System.Random rand;
    private GameObject[] generatedWoodSticks;
    void Start()
    {
        generatedWoodSticks = new GameObject[num];
        rand = new System.Random();

        Generate();
    }

    public void Generate(){
        int count = 0;

        while(count < num){
            float posX = GetRandomNumber(minPosX, maxPosX);
            float posZ = GetRandomNumber(minPosZ, maxPosZ);
            
            bool willCollide = Physics.CheckCapsule(new Vector3(posX, posY * capsuleHeight, posZ), new Vector3(posX, posY * capsuleHeight, (posZ + 2)), 0.15f);
            
            if(!willCollide){
                generatedWoodSticks[count] = Instantiate(WoodStickPrefab, new Vector3(posX, posY, posZ), Quaternion.Euler(0, 90, 0));
                count++;
            } 
        }
    }

    private float GetRandomNumber(float min, float max){
        double range = max - min;
        double sample = rand.NextDouble();
        double num = (sample * range) + min;
        return (float) num;
    }

     public void OnNewDay(){
        DestroysCurrentSticks();
        Generate();
    }


    private void DestroysCurrentSticks(){
        foreach (GameObject stick in generatedWoodSticks)
        {
            if(stick != null){
                Destroy(stick);  
            }
        }
    }
}
