using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildButtonController : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{

    public GameObject shelter;
    private RectTransform backgroundRectTransform;
    private Image backgroundImage;
    private Color defaultBackgorundColor;
    private Vector2 backgroundSize;
    private GameObject outline;

    private GameObject character;
    private bool isEnabled = true;

    public bool buildDone = false;


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
        if(isEnabled)
        {
            buidShelter();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(isEnabled)
        {
            backgroundRectTransform.sizeDelta = new Vector2(312, 312);
            var tempColor = backgroundImage.color;
            tempColor.a = 255;
            backgroundImage.color = tempColor;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    public void Enable(GameObject character){
        isEnabled = true;
        this.character = character;
        outline.SetActive(true);
        backgroundImage.color = defaultBackgorundColor;
    }
    
    public void Disable(){
        isEnabled = false;
        outline.SetActive(false);
        backgroundImage.color = new Color(255, 0, 0, 128);
    }

    private void buidShelter(){
         Vector3 position = character.transform.GetChild(2).position;
        Instantiate(shelter, position, Quaternion.identity);
        buildDone = true;
    }

    
}
