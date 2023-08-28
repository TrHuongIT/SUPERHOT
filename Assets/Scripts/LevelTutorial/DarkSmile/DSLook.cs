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
        xRotation = Mathf.Clamp(xRotation, -85f, 85f); //Gi?i h?n góc t?i ?a th? hi?n nhìn lên và nhìn xu?ng
        m_Camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //Di chu?t lên/xu?ng là mouseY - còn quay lên/xu?ng là tr?c x trong Unity

        //Left and Right
        transform.Rotate(Vector3.up * mouseX * Time.deltaTime * xSensitivity); //Vector3.up là tr?c y Unity (trái/ph?i) - v?i vi?c di chu?t trái/ph?i là mouseX

    }
}
