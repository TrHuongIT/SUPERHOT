using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSLook : MonoBehaviour
{
    public Camera m_Camera;

    private float xRotation = 0f;
    private float xSensitivity = 80f;
    private float ySensitivity = 80f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LookByMouse(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //Up and Down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f); //Gi?i h?n g�c t?i ?a th? hi?n nh�n l�n v� nh�n xu?ng
        m_Camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //Di chu?t l�n/xu?ng l� mouseY - c�n quay l�n/xu?ng l� tr?c x trong Unity

        //Left and Right
        transform.Rotate(Vector3.up * mouseX * Time.deltaTime * xSensitivity); //Vector3.up l� tr?c y Unity (tr�i/ph?i) - v?i vi?c di chu?t tr�i/ph?i l� mouseX

    }
}
