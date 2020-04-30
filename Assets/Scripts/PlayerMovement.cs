using UnityEngine;


[RequireComponent(typeof(PlayerDirection))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private CharacterController characterController;
    private PlayerDirection playerDirection;

    private float gravityScale = .5f;
    private float jumpForce = 500f;

    private Vector3 velocity;
    private float yVelocity = 0f;
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
                yVelocity = jumpForce * Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                canDoubleJump = false;
                yVelocity = jumpForce * Time.deltaTime;
            }

            yVelocity -= gravityScale;
        }

        velocity.y = yVelocity;
    }

    private void CalculateVelocity()
    {
        velocity = playerDirection.Direction * _movementSpeed;
        velocity = transform.TransformDirection(velocity);
    }
   
}
