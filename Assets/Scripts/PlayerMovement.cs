using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerDirection))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private CharacterController characterController;
    private PlayerDirection playerDirection;

    private Vector3 velocity;
    private float gravityScale = .5f;
    private float yVelocity = 0f;
    private float jumpForce = 30f;

    private bool canDoubleJump;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerDirection = GetComponent<PlayerDirection>();
    }

    void Update()
    {
        CalculateVelocity();
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
                yVelocity = jumpForce;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                canDoubleJump = false;
                yVelocity = jumpForce;
            }
            yVelocity -= gravityScale;
        }

        velocity.y = yVelocity;
    }

    private void CalculateVelocity()
    {
        velocity= playerDirection.Direction * _movementSpeed;
    }
   
}
