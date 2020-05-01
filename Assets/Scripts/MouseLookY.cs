using UnityEngine;

public class MouseLookY : MonoBehaviour
{
    [SerializeField] [Range(5f, 15f)] private float mouseSensivity = 10f;

    private Vector3 tempAngles = Vector3.zero;
    private float sensivityMultiplier = 10f;
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    
}
