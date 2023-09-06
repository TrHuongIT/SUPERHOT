using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DSInteracable : MonoBehaviour
{
    public string promptMess; //show name Object Interacable

    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {

    }
}
