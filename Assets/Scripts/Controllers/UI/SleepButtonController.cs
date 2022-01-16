using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SleepButtonController : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform backgroundRectTransform;
    private Image backgroundImage;
    private Color defaultBackgorundColor;
    private Vector2 backgroundSize;
    private GameObject outline;
    public TimeManager timeManager;
    public bool sleepPressed = false;


    // Awake is called even if the script is disabled. 
    void Awake()
    {
        outline = transform.GetChild(0).gameObject;
        GameObject backgroundGameObject = transform.GetChild(1).gameObject;
        backgroundRectTransform = backgroundGameObject.GetComponent<RectTransform>();
        backgroundImage = backgroundGameObject.GetComponent<Image>();
        defaultBackgorundColor = backgroundImage.color;
        backgroundSize = backgroundRectTransform.sizeDelta;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        timeManager.fastNight();
        sleepPressed = true;
    }

     public void OnPointerDown(PointerEventData eventData)
    {
        backgroundRectTransform.sizeDelta = new Vector2(312, 312);
        var tempColor = backgroundImage.color;
        tempColor.a = 255;
         backgroundImage.color = tempColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    public void Reset(){
        sleepPressed = false;
    }
}
