using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float movementSpeed;

    [Header("Gravity Options")]
    [SerializeField] [Range(-80f, 0f)] private float gravityScale = -40f;
    [SerializeField] [Range(2f, 30f)] private float jumpHeight = 5f;

    [Header("Ground Options")]
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Button Options")]
    [SerializeField] private string jumpButton = "Jump";

    private Vector3 movementDirection;
    private Vector3 verticalVelocity;
    private bool canDoubleJump;
    private bool isGrounded;

    public bool CanDoubleJump { get => canDoubleJump; set => canDoubleJump = value; }
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }

    void Start()
    {
        characterController = GetComponent<CharacterController>();        
    }

    void Update()
    {

        HorizontalMovement();
        VerticalMovement();
        Jump();

        Debug.Log(GroundCheck());
    }

    private void Jump()
    {
        if (characterController.isGrounded && Input.GetButtonDown(jumpButton))
        {
            verticalVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravityScale);
            CanDoubleJump = true;
        }
        else if (Input.GetButtonDown(jumpButton) && CanDoubleJump)
        {
            CanDoubleJump = false;
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

    private bool GroundCheck()
    {
       return Physics.CheckSphere(groundCheckTransform.position, groundCheckRadius, whatIsGround);
    }

}
