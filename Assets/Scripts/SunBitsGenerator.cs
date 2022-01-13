using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SunBitsGenerator : MonoBehaviour
{
    public GameObject sunBitPrefab;
    public int num = 20;
    public float minPosX = -88;
    public float maxPosX = 90;
    public float minPosZ = -70;
    public float maxPosZ = 74;
    public float posY = 2.4f;

    GameObject[] generatedSunBits;

    // Start is called before the first frame update
    void Start()
    {
        generatedSunBits = new GameObject[num];

        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate(){
        System.Random rand = new System.Random();
        double xRange = maxPosX - minPosX;
        double zRange = maxPosZ - minPosZ;
        Debug.Log("range X= " + xRange + " rangeZ= " + zRange);
        for(int i = 0; i < num; i++){
             double sample = rand.Next();
             double posX = (sample * xRange) + minPosX;
             double posZ = (sample * zRange) + minPosZ;
             Debug.Log("x= " + posX + ", y= " + posY + ", z= " + posZ);
             generatedSunBits[i] = Instantiate(sunBitPrefab, new Vector3((float) posX, posY, (float) posZ), Quaternion.identity);
        }
    }
}
