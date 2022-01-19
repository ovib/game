using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class TimeManager : MonoBehaviour
{
    public ShelterController shelterController;
    public ActionButtonsManager actionButtonsManager;
    public float timeMultiplier;
    public float percentageIncreaseOnNewDay = 0.1f;
    public float additionalFastNightMultiplier = 25;
    public float startHour;
    public float sunriseHour;
    public float sunsetHour;
    public Light sunLight;
    public TextMeshProUGUI timeText;
    public SunBitsGenerator sunBitsGenerator;
    public WoodSticksGenerator woodSticksGenerator;

    [System.NonSerialized]
    public DateTime currentTime; 
    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;

    private float dayPercentage; // used in the GameBar

    [System.NonSerialized]
    public bool isNight;

    private DateTime nextDay;
    


    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
        UpdateNextDay();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
        NewDayRoutine();
    }

    private void UpdateTimeOfDay(){
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        if(timeText.text != null) timeText.text = currentTime.ToString("HH:mm");
    }

    private void RotateSun()
    {
        float sunLightRotation;

        if(currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime){ // daytime
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);
            
            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;
            // Debug.Log("Day percentage: " + percentage);

            // 0 at sunrise than increases linearly as the day progresses
            // reaches 180 at sunset
            sunLightRotation = Mathf.Lerp(0, 180, (float) percentage);

            isNight = false;
            dayPercentage = (float) percentage;

        } else { // nightTime
            TimeSpan sunsetToSunRiseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);
            
            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunRiseDuration.TotalMinutes;
            // Debug.Log("Night percentage: " + percentage);

            sunLightRotation = Mathf.Lerp(180, 360, (float) percentage);

            isNight = true;
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

    public void IncreaseDay(int minutes){
        DateTime increasedTime =  currentTime.AddMinutes(- (double) minutes);
        DateTime currentDaySunriseTime = DateTime.Now.Date + TimeSpan.FromHours(sunriseHour);

        if(increasedTime < currentDaySunriseTime){ // prevent from going back to the previous night
            currentTime = currentDaySunriseTime;
        } else {
            currentTime = currentTime.AddMinutes(- (double) minutes);
        }
        
    }

    // called on sleep button pressed, makes night super fast
    public void fastNight(){
        StartCoroutine(fastNightCoroutine());
    }

    private IEnumerator fastNightCoroutine(){
        DateTime startDate = currentTime.Date;
        timeMultiplier = timeMultiplier * additionalFastNightMultiplier;
        while(isNight || currentTime.Date == startDate){
            yield return null;
        }
        timeMultiplier = timeMultiplier / additionalFastNightMultiplier;
    }

    private void NewDayRoutine(){
        if(currentTime.Date == nextDay){
            UpdateNextDay();
            IncreaseDifficulty();
            actionButtonsManager.OnNewDay();
            woodSticksGenerator.OnNewDay();
            sunBitsGenerator.OnNewDay();
            shelterController.DestroyShelter();
            shelterController.Reset();
        }
    }

    private void UpdateNextDay(){
        nextDay = currentTime.Date.AddDays(1);
    }

    private void IncreaseDifficulty(){
        timeMultiplier += timeMultiplier * percentageIncreaseOnNewDay;
    }
}