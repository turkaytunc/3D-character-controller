﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float movementSpeed;

    [Header("Gravity Options")]
    private float gravityScale = 9.81f;
    private float jumpHeight = 50000f;

    private Vector3 movementDirection;
    private Vector3 velocity;
    private float yVelocity = 0f;
    private bool canDoubleJump;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        gravityScale = jumpHeight / (2 * (Time.deltaTime * Time.deltaTime));

        GetPlayerDirectionInput();
        CalculateHorizontalVelocity();
        CalculateVerticalVelocity();

        characterController.Move(velocity * Time.deltaTime);
    }

    private void CalculateVerticalVelocity()
    {
        if (characterController.isGrounded)
        {   
            if (Input.GetKeyDown(KeyCode.Space))
            {
                canDoubleJump = true;
                yVelocity = Mathf.Sqrt(2 * jumpHeight * gravityScale );
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                canDoubleJump = false;
                yVelocity = Mathf.Sqrt(2 * jumpHeight * gravityScale);
            }

            yVelocity -= gravityScale;
        }

        velocity.y = yVelocity;
    }

    private void CalculateHorizontalVelocity()
    {
        velocity = movementDirection * movementSpeed;
        velocity = transform.TransformDirection(velocity);
    }

    private void GetPlayerDirectionInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalInput, 0, verticalInput);
    }

}
