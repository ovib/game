using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThirdPersonInput : MonoBehaviour
{


    public FloatingJoystick joystick;
    public float walkSpeed = 10;
    public float runSpeed = 25;
    public float moveSpeed;
    private Transform objectTransform; // includes camera
    private Transform modelTransform;
    private CharacterController myCaracterController;
    private Animator animator;
    private float verticalMovement;
    private float horizontalMovement;


    // Start is called before the first frame update
    void Start()
    {
     objectTransform = GetComponent<Transform>();
     modelTransform = objectTransform.GetChild(0);
     myCaracterController = GetComponent<CharacterController>();   
     animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       Move();
    }

    private void Move(){
        verticalMovement =  joystick.Vertical;
        horizontalMovement = joystick.Horizontal;
        Vector2 joystickDirection = joystick.Direction;
        // Debug.Log("Vertical: " + verticalMovement + ". Horizontal: " + horizontalMovement);

        if(verticalMovement != 0 && horizontalMovement != 0){
          myCaracterController.Move(objectTransform.TransformDirection(new Vector3(horizontalMovement, 0, verticalMovement)  * moveSpeed * Time.deltaTime));  
          modelTransform.rotation = Quaternion.LookRotation(new Vector3(joystickDirection.x, 0, joystickDirection.y) * moveSpeed * Time.deltaTime);
        }

        if(verticalMovement == 0 && horizontalMovement == 0){
            Idle();
        } else if(Math.Abs(verticalMovement) < 0.51f && Math.Abs(horizontalMovement) < 0.51f){
            Walk();
        } else {
            Run();
        }
    }

    private void Idle(){
        animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk(){
        moveSpeed = walkSpeed;
        animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run(){
        moveSpeed = runSpeed;
        animator.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }


    

}
