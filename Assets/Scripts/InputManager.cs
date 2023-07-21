using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.PlayerActions playerMoveLookAndJumpActions;

    private PlayerMovement playerMovement;
    private PlayerLook playerLook;
    
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        playerMoveLookAndJumpActions = playerInput.Player;

        playerMovement = GetComponent<PlayerMovement>();
        playerMoveLookAndJumpActions.Jump.performed += ctx => playerMovement.Jump();

        playerLook = GetComponent<PlayerLook>();

        
        
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        playerMovement.PlayerMoveAndMove(playerMoveLookAndJumpActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerLook.PlayerLookByMouse(playerMoveLookAndJumpActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable() 
    {
        playerMoveLookAndJumpActions.Enable();
    }

    private void OnDisable()
    {
        playerMoveLookAndJumpActions.Disable();
    }
}
