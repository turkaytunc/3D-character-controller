using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float movementSpeed;

    [Header("Gravity Options")]
    private float gravityScale = -9.81f;
    private float jumpHeight = 20f;

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
        
        if (characterController.isGrounded)
        {
            velocity.y = 0;
        }

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
                yVelocity = -(2 * jumpHeight * gravityScale * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                canDoubleJump = false;
                yVelocity = -(2 * jumpHeight * gravityScale * Time.deltaTime);
            }

            yVelocity += gravityScale * Time.deltaTime;
        }

        velocity.y = yVelocity;
    }

    private void CalculateHorizontalVelocity()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        velocity = transform.TransformDirection(movementDirection * movementSpeed * Time.deltaTime);
    }


}
