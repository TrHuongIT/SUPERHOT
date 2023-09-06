using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSLook : MonoBehaviour
{
    public Camera mainCamera;
    private float xRot = 0f;

    private float xSensitivy = 60f;
    private float ySensitivy = 60f;

    private void Start()
    {
    }

    public void dsLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRot -= (mouseY * Time.deltaTime) * ySensitivy;
        xRot = Mathf.Clamp(xRot, -85f, 85f);

        mainCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        transform.Rotate(0, mouseX * xSensitivy * Time.deltaTime, 0);
            
    }
}
