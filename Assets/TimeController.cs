using UnityEngine;
using TMPro;
using System;

public class TimeController : MonoBehaviour
{

    public float timeMultiplier;
    public float startHour;
    public float sunriseHour;
    public float sunsetHour;
    public Light sunLight;
    public TextMeshProUGUI timeText;
    private DateTime currentTime;
    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;

    private float dayPercentage; // used in the GameBar

    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
    }

    private void UpdateTimeOfDay(){
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        if(timeText.text != null) timeText.text = currentTime.ToString("HH:mm");
    }

    private void RotateSun(){
        float sunLightRotation;

        if(currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime){ // daytime
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);
            
            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;
            // Debug.Log("Day percentage: " + percentage);

            // 0 at sunrise than increases linearly as the day progresses
            // reaches 180 at sunset
            sunLightRotation = Mathf.Lerp(0, 180, (float) percentage);

            dayPercentage = (float) percentage;
        

        } else { // nightTime
            TimeSpan sunsetToSunRiseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);
            
            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunRiseDuration.TotalMinutes;
            // Debug.Log("Night percentage: " + percentage);

            sunLightRotation = Mathf.Lerp(180, 360, (float) percentage);

            dayPercentage = 0;
        }

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right); // vector3.right = rotate around the x axes
    }

    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime){
        TimeSpan difference = toTime - fromTime;

        if(difference.TotalSeconds < 0){ // timeSpan from two different days
            difference += TimeSpan.FromHours(24);
        }
        return difference;
    }

    public float GetDayPercentage(){
        return dayPercentage;
    }
}
