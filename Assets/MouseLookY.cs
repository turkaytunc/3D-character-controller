using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookY : MonoBehaviour
{
    [SerializeField] [Range(0.5f, 5f)] private float mouseSensivity;
    void Update()
    {
        LookAtX();
    }

    private void LookAtX()
    {
        float mouseXPos = Input.GetAxis("Mouse Y") * mouseSensivity;
        Vector3 tempAngles = transform.localEulerAngles;
        tempAngles.x -=  mouseXPos;

        transform.localEulerAngles = tempAngles;
    }
}
