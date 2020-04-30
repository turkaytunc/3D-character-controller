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




        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (mouseX * mouseSensivity), transform.localEulerAngles.z);
    }
}
