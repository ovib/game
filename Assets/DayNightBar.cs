using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayNightBar : MonoBehaviour
{
    public Slider slider;
    public TimeController timeController;

    void Update()
    {
        float dayPercentage = timeController.GetDayPercentage();
        if(dayPercentage == 0){ // is Night
            slider.value = slider.maxValue;
        } else {
            slider.value = dayPercentage;
        }

    }

}
