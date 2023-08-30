using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSLook : MonoBehaviour
{
    public Camera m_camera;

    private float xRotation = 0f;

    private float xSensivity = 80f;
    private float ySensivity = 80f;

    public void dsLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensivity;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);
        m_camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //Chuyen dong cua Camera
        transform.Rotate(transform.rotation.x, mouseX * xSensivity * Time.deltaTime, transform.rotation.z); //Chuyen dong cua tranform cua Object duoc gan script

    }
}
