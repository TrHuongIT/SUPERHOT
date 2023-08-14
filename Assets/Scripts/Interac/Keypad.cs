using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]private GameObject door;
    private bool doorOpen;    

    protected override void Interact()
    {
        Debug.Log("Tuong tac voi: " + gameObject.name);
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
    }
}
