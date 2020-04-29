using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private CharacterController _characterController;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = CalculateVelocity();

        _characterController.Move(velocity * Time.deltaTime);
    }

    private Vector3 CalculateVelocity()
    {
        Vector3 direction = GetPlayerDirectionInput();

        Vector3 velocity = direction * _movementSpeed;
        return velocity;
    }

    private static Vector3 GetPlayerDirectionInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        return direction;
    }
}
