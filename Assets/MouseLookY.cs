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
        float mouseX = Input.GetAxis("Mouse Y");

        Vector3 tempAngles = transform.localEulerAngles;
        tempAngles.x -=  mouseX* mouseSensivity;
        transform.localEulerAngles = tempAngles;
    }
}
