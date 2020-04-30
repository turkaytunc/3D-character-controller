using UnityEngine;

public class MouseLookX : MonoBehaviour
{
    [SerializeField] [Range(0.5f, 5f)] private float mouseSensivity;
    void Update()
    {
        LookAtX();
    }

    private void LookAtX()
    {
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 tempAngles = transform.localEulerAngles;
        tempAngles.y += (mouseX * mouseSensivity);
        transform.localEulerAngles = tempAngles;
    }
}
