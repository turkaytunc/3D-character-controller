using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private CharacterController _characterController;
    private PlayerDirection _playerDirection;

    private Vector3 _velocity;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerDirection = GetComponent<PlayerDirection>();
    }

    void Update()
    {
        CalculateVelocity();

        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void CalculateVelocity()
    {
        _velocity= _playerDirection.Direction * _movementSpeed;
    }
   
}
