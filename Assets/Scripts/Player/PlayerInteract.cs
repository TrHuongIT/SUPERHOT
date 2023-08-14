using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 3f;

    public LayerMask mask;
    private PlayrUI playrUI;
    private InputManager inputManager;
    void Start()
    {
        cam = GetComponent<PlayerLook>().mainCamera;
        playrUI = GetComponent<PlayrUI>();
        inputManager = GetComponent<InputManager>();
        
    }
    void Update()
    {
        playrUI.UpdateText(string.Empty); 
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playrUI.UpdateText(interactable.promptMessage);
                if (inputManager.playerActions.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
        
    }
}
