using UnityEngine;

public class MouseLookX : MonoBehaviour
{
    [SerializeField] [Range(0.5f, 3f)] private float mouseSensivity;
    void Update()
    {
        LookAtX();
    }

    private void LookAtX()
    {
        float mouseX = Input.GetAxis("Mouse X");


        Quaternion quaternion = Quaternion.Euler(new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (mouseX * mouseSensivity), transform.localEulerAngles.z));

        transform.rotation = quaternion;
    }
}
