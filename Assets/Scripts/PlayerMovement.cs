using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    
    private Vector3 velocity;
    private bool onTheGround;
    
    // Update is called once per frame
    void Update() {
        onTheGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (onTheGround && velocity.y < 0f) {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //player movement
        Vector3 movement = transform.forward * z + transform.right * x;
        characterController.Move(movement * speed * Time.deltaTime);

        if (Input.GetButton("Jump") && onTheGround) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f  * gravity);
        }
        //player gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}