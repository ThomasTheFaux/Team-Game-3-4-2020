using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

    //Purpose... 
    //  + Player Movement
    //  - Upgrade Towers
    //  - Repair Towers
    //
    //Script By Thomas Joyce

public class PlayerController : MonoBehaviour {
    
    //Movement variables
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDist = 0.4f;
    public float gravity = -9.81f;      
    public float speed = 6f;                                    //current speed of player
    float speedWalk = 6f;                                       //normal speed of player
    float speedSpr = 0f;                                        //sprint speed of player
    float jumpHeight = 1f;                                      //height of jump
    Vector3 velocity;
    bool isGrounded;                                            //if true, you are on the ground
    


    void Start(){
        controller = GetComponent<CharacterController>();
        speedWalk = speed;
        speedSpr = speed * 1.5f;
    }
    
    void Update(){
        movement();
        jumping();
        sprinting();
    }

    //handles character movement
    void movement(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //handles jumping
    void jumping(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if(isGrounded && Input.GetKeyDown("space")){
            float jumpVel = Mathf.Sqrt (-2 * gravity * jumpHeight);
            velocity.y = jumpVel;
        }
    }

    //handles sprinting
    void sprinting(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if(isGrounded && Input.GetKeyDown(KeyCode.LeftShift)){
            speed = speedSpr;
        }

        if(isGrounded && Input.GetKeyUp(KeyCode.LeftShift)){
            speed = speedWalk;
        }

        //checks if player is on ground, if not resets speed
        if(!isGrounded){
            speed = 9f;
        }
    }

    //repairs turret
    void repairTurret(){

    }

    //opens upgrade menu
    void upgradeTurret(){

    }
}
