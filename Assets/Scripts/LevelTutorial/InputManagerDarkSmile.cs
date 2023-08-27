using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerDarkSmile : MonoBehaviour
{
    private DarkSmileInput darkSmileInput;
    public DarkSmileInput.DarkSmileActions darkSmileActions;

    private DarkSmileMovement darkSmileMovement;

    private void Awake()
    {
        darkSmileInput = new DarkSmileInput();
        darkSmileActions = darkSmileInput.DarkSmile;
        darkSmileMovement = GetComponent<DarkSmileMovement>();

        darkSmileActions.Jump.performed += ctx => darkSmileMovement.Jump();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        darkSmileMovement.DSMove(darkSmileActions.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        darkSmileActions.Enable();
    }

    private void OnDisable()
    {
        darkSmileActions.Disable();
    }
}
