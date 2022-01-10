using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayNightBarController : MonoBehaviour
{
    public Slider slider;
    public TimeManager timeManager;

    void Update()
    {
        float dayPercentage = timeManager.GetDayPercentage();
        if(dayPercentage == 0){ // is Night
            slider.value = slider.maxValue;
        } else {
            slider.value = dayPercentage;
        }

    }

}
