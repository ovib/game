using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildButtonController : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{

    private RectTransform backgroundRectTransform;
    private Image backgoroundImage;
    private Vector2 backgroundSize;


    // Start is called before the first frame update
    void Start()
    {
        GameObject backgroundGameObject = transform.GetChild(1).gameObject;
        backgroundRectTransform = backgroundGameObject.GetComponent<RectTransform>();
        backgoroundImage = backgroundGameObject.GetComponent<Image>();
        backgroundSize = backgroundRectTransform.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("BUILD PRESSED");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        backgroundRectTransform.sizeDelta = new Vector2(312, 312);
        var tempColor = backgoroundImage.color;
        tempColor.a = 255;
        backgoroundImage.color = tempColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    
}
