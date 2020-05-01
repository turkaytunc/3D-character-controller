using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] [Range(10f, 30f)] private float mouseSensivityXAxis = 10f;
    [SerializeField] [Range(10f, 30f)] private float mouseSensivityYAxis = 10f;


    [SerializeField] private Transform playerControllerTransform;
    [SerializeField] private GameObject playerCamera;

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
        tempAngles.x = Mathf.Clamp(tempAngles.x, -50f, 50f);
        playerCamera.transform.localRotation = Quaternion.Euler(tempAngles);
    }

    private void GetPlayerInput()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float mouseXInput = Input.GetAxis("Mouse X") * mouseSensivityXAxis * Time.deltaTime;
        float mouseYInput = Input.GetAxis("Mouse Y") * mouseSensivityYAxis * Time.deltaTime;
        
        inputValue = new Vector2(mouseXInput, mouseYInput);   
    }
}
