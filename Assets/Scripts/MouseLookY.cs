using UnityEngine;

public class MouseLookY : MonoBehaviour
{
    [SerializeField] [Range(4f, 8f)] private float mouseSensivity = 4f;

    private Vector3 tempAngles = Vector3.zero;
    private float sensivityMultiplier = 10f;
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        LookAtY();
    }

    private void LookAtY()
    {
        float mouseYPos = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime * sensivityMultiplier;
        tempAngles.x -=  mouseYPos;
        tempAngles.x = Mathf.Clamp(tempAngles.x, -50f, 50f);
        transform.localRotation = Quaternion.Euler(tempAngles);
    }
}
