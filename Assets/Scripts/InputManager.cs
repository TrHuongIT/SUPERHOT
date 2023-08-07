using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.PlayerActions playerActions;

    private PlayerMovement playerMovement;
    private PlayerLook playerLook;
    
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        playerActions = playerInput.Player;

        playerMovement = GetComponent<PlayerMovement>();
        playerActions.Jump.performed += ctx => playerMovement.Jump();

        playerActions.Crouch.performed += ctx => playerMovement.Crouch();
        playerActions.Sprint.performed += ctx => playerMovement.Sprint();

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
        playerMovement.PlayerMoveAndMove(playerActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerLook.PlayerLookByMouse(playerActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable() 
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }
}
