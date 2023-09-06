using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerDarkSmile : MonoBehaviour
{
    private DarkSmileInput dsInput;
    public DarkSmileInput.DarkSmileActions dsActions;

    private DarkSmileMovement darkSmileMovement;
    private DSLook darksmileLook;

    private void Awake()
    {
        dsInput = new DarkSmileInput();
        dsActions = dsInput.DarkSmile;

        darkSmileMovement = GetComponent<DarkSmileMovement>();
        dsActions.Jump.performed += ctx => darkSmileMovement.Jump();
        dsActions.Sprint.performed += ctx => darkSmileMovement.dsSprint();
        dsActions.Crawl.performed += ctx => darkSmileMovement.dsCrawl();

        darksmileLook = GetComponent<DSLook>();
    }

    private void FixedUpdate()
    {
        darkSmileMovement.dsMove(dsActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        darksmileLook.dsLook(dsActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        dsActions.Enable();
    }

    private void OnDisable()
    {
        dsActions.Disable();
    }
}
