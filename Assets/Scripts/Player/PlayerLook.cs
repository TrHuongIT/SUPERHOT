using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera mainCamera;

    private float xRot = 0f;

    private float xSensitivity = 80f;
    private float ySensitivity = 80f;

    public void PlayerLookByMouse(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRot -= (mouseY * Time.deltaTime) * ySensitivity;
        xRot = Mathf.Clamp(xRot, -80f, 80f);

        mainCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        //rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
