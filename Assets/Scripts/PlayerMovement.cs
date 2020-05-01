using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float movementSpeed;

    [Header("Gravity Options")]
    private float gravityScale = -9.81f;
    private float jumpHeight = 20f;
    private float mass = 2f;

    private Vector3 movementDirection;
    private Vector3 verticalVelocity;
    private bool canDoubleJump;


    void Start()
    {
        characterController = GetComponent<CharacterController>();        
    }

    void Update()
    {      

        HorizontalMovement();
        
        VerticalMovement();

        if(characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity.y = jumpHeight / mass;
            canDoubleJump = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
        {
            canDoubleJump = false;
            verticalVelocity.y = jumpHeight / mass;
        }
    }

    private void VerticalMovement()
    {
        if (characterController.isGrounded && verticalVelocity.y < 0f)
        {
            verticalVelocity.y = 0f;
        }
        else
        {
            verticalVelocity.y += gravityScale * Time.deltaTime;
        }

        characterController.Move(verticalVelocity * Time.deltaTime);
    }

    private void HorizontalMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection = transform.TransformDirection(movementDirection);

        characterController.Move(movementDirection * movementSpeed * Time.deltaTime);

    }


}
