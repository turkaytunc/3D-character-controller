using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float movementSpeed;

    [Header("Gravity Options")]
    [SerializeField] [Range(-80, 0f)] private float gravityScale = -40f;
    [SerializeField] [Range(2f, 30f)] private float jumpHeight = 5f;

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
        Jump();
    }

    private void Jump()
    {
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravityScale);
            canDoubleJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
        {
            canDoubleJump = false;
            verticalVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravityScale);
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
