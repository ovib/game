using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SunBitsGenerator : MonoBehaviour
{
    public GameObject sunBitPrefab;
    public AudioClip audioClip;
    public int num = 10;
    public float minPosX = -88;
    public float maxPosX = 90;
    public float minPosZ = -70;
    public float maxPosZ = 74;
    public float posY = 2.4f;

    GameObject[] generatedSunBits;

    private System.Random rand;

    void Start()
    {
        generatedSunBits = new GameObject[num];
        rand = new System.Random();

        Generate();
    }

    public void Generate(){
        int count = 0;

        while(count < num){
            float posX = GetRandomNumber(minPosX, maxPosX);
            float posZ = GetRandomNumber(minPosZ, maxPosZ);
            
            bool willCollide = Physics.CheckSphere(new Vector3(posX, posY, posZ), 0.8f);
            
            if(!willCollide){
                generatedSunBits[count] = Instantiate(sunBitPrefab, new Vector3(posX, posY, posZ), Quaternion.identity);
                AudioSource audioSource =generatedSunBits[count].AddComponent<AudioSource>();
                audioSource.clip = audioClip;
                audioSource.playOnAwake = false;
                
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
        DestroysCurrentBits();
        Generate();
    }


    private void DestroysCurrentBits(){
        foreach (GameObject sunBit in generatedSunBits)
        {
            if(sunBit != null){
                Destroy(sunBit);  
            }
        }
    }

}
