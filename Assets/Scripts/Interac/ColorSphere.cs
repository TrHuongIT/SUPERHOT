using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSphere : Interactable
{
    private MeshRenderer mesh;
    public Color[] color;
    private int colorIndex;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = Color.red;
        
    }

    protected override void Interact()
    {
        colorIndex++;
        if (colorIndex > color.Length - 1)
        {
            colorIndex = 0;
        }
        mesh.material.color = color[colorIndex];
    }
}
