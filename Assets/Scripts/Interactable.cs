using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    public string promptMessage;
    public bool useEvents;

    public virtual string OnLook()
    {
        return promptMessage;
    }
    public void BaseInteract()
    {
        if (useEvents) GetComponent<InteractEvent>().OnInteract.Invoke();
        Interact();
    }

    protected virtual void Interact()
    {

    }


}
