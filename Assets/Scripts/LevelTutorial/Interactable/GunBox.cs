using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBox : DSInteracable
{
    protected override void Interact()
    {
        Debug.Log("This is "+gameObject.name);
    }

}
