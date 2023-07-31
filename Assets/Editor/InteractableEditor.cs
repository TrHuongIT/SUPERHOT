using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        base.OnInspectorGUI();
        if (interactable.useEvents)
        {
            if(interactable.GetComponent<InteractEvent>() == null) 
                 interactable.gameObject.AddComponent<InteractEvent>();
        } else
        {
            if(interactable.GetComponent<InteractEvent>() != null)
            {
                DestroyImmediate(interactable.GetComponent<InteractEvent>());
            }
        }
    }
}
