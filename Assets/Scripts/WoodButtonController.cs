using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodButtonController : MonoBehaviour
{
    public int minSticks = 5;
    private int current = 0;
    private TextMeshProUGUI text;

    // [System.NonSerialized]
    public bool limitReached = false;

    // Start is called before the first frame update
    void Start()
    {
    GameObject textGameObject = transform.GetChild(2).gameObject;

    //  Component[] components = textGameObject.GetComponents(typeof(Component));
    // foreach(Component component in components) {
    //     Debug.Log(component.ToString());
    // }
    
        text = textGameObject.GetComponent<TextMeshProUGUI>();
        // Debug.Log("current text: " + text.text);
        text.text = current + " / " + minSticks;
    }

    void Update(){
        limitReached = current >= minSticks;
    }

    public void UpdateButton(){
        current +=1;
        text.text = current + " / " + minSticks;
    }

    public void Reset(){
        current = -1;
        UpdateButton();
        limitReached = false;
    }


}
