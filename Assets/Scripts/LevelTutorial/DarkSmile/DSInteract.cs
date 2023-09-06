using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DSInteract : MonoBehaviour
{
    private Camera cam;
    private bool hasHit;
    private float maxDistance = 10f;
    [SerializeField] private LayerMask mask;

    private DSIU showText;

    private InputManagerDarkSmile inputDS;

    private void Start()
    {
        cam = GetComponent<DSLook>().mainCamera;
        showText = GetComponent<DSIU>();
        inputDS = GetComponent<InputManagerDarkSmile>();
    }

    private void Update()
    {
        showText.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.yellow);

        hasHit = Physics.Raycast(ray, out RaycastHit hitInfor, maxDistance, mask);
        if(hasHit)
        {
            if(hitInfor.collider.GetComponent<DSInteracable>() != null)
            {
                DSInteracable interacable = hitInfor.collider.GetComponent<DSInteracable>();
                showText.UpdateText(interacable.promptMess);
                if (inputDS.dsActions.Interact.triggered)
                {
                    interacable.BaseInteract();
                }
            }
        }

    }
}
