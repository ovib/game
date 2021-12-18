using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonInput : MonoBehaviour
{


    public FloatingJoystick joystick;
    public float speed = 10;
    private Transform objectTransform; // includes camera
    private Transform modelTransform;
    private CharacterController myCaracterController;

    // public float verticalSpeed = 10;

    private float verticalMovement;
    private float horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
     objectTransform = GetComponent<Transform>();
     modelTransform = objectTransform.GetChild(0);
     myCaracterController = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
       verticalMovement =  joystick.Vertical;
       horizontalMovement = joystick.Horizontal;
       Vector2 joystickDirection = joystick.Direction;
       // Debug.Log("vertical: " + verticalMovement);
      
      if(verticalMovement != 0 && horizontalMovement != 0){
          myCaracterController.Move(objectTransform.TransformDirection(new Vector3( verticalMovement, 0, -horizontalMovement)  * speed * Time.deltaTime));  
          modelTransform.rotation = Quaternion.LookRotation(new Vector3(joystickDirection.x, 0, joystickDirection.y) * speed * Time.deltaTime);
      }
    }

}
