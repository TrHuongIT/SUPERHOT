using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeForDestroy : Interactable
{
    public GameObject breakCube;


    protected override void Interact()
    {
        Destroy(gameObject);
    }
}
