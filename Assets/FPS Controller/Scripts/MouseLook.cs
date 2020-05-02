using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Mouse Sensivity")]
    [SerializeField] [Range(100f, 200f)] private float mouseSensivityXAxis = 150f;
    [SerializeField] [Range(100f, 200f)] private float mouseSensivityYAxis = 130f;


    [SerializeField] private Transform playerControllerTransform;
    [SerializeField] private Transform playerCameraTransform;

    [Header("Camera X Rotation")]
    [SerializeField] [Range(-60f, -40f)] private float minCameraXRotationAngle = -50f;
    [SerializeField] [Range(40f, 60f)] private float maxCameraXRotationAngle = 50f;
    

    private Vector2 inputValue;
    private Vector3 tempAngles = Vector3.zero;

    void Update()
    {
        GetPlayerInput();

        LookAtX();
        LookAtY();
    }

    private void LookAtX()
    {
        playerControllerTransform.Rotate(new Vector3(0, inputValue.x, 0));
    }

    private void LookAtY()
    {
        tempAngles.x -= inputValue.y;
        tempAngles.x = Mathf.Clamp(tempAngles.x, minCameraXRotationAngle, maxCameraXRotationAngle);
        playerCameraTransform.localRotation = Quaternion.Euler(tempAngles);
    }

    private void GetPlayerInput()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float mouseXInput = Input.GetAxis("Mouse X") * mouseSensivityXAxis * Time.deltaTime;
        float mouseYInput = Input.GetAxis("Mouse Y") * mouseSensivityYAxis * Time.deltaTime;
        
        inputValue = new Vector2(mouseXInput, mouseYInput);   
    }
}
