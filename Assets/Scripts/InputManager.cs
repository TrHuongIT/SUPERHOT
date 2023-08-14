using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //Tạo biến playerInput để tham chiếu tới class PlayerInput
    private PlayerInput playerInput;

    //Tạo biến playerAcions để tham chiếu đến toàn bộ các Actions của mục Player trong mục "Action Maps" của package Input System
    public PlayerInput.PlayerActions playerActions;

    //Tạo biến playerMovement để tham chiếu tới class PlayerMovement
    private PlayerMovement playerMovement;
    //Tạo biến playerLook để tham chiếu tới class PlayerLook
    private PlayerLook playerLook;
    
    
    void Awake()
    {
        //Khởi tạo đối tượng PlayerInput
        //Lưu ý rằng khi bạn khởi tạo một biến như private PlayerInput playerInput;, bạn chỉ khai báo một tham chiếu đến đối tượng kiểu PlayerInput,
        //và đối tượng thực sự sẽ được tạo ra bằng cách sử dụng từ khóa new
        playerInput = new PlayerInput();
        //Gán các hành động từ mục Player trong Input Actions cho biến playerActions
        playerActions = playerInput.Player;

        //Tham chiếu đến component <PlayerMovement> của Object được gắn nó
        playerMovement = GetComponent<PlayerMovement>();
        //Tham chiếu đến component <PlayerLook> của Object được gắn nó
        playerLook = GetComponent<PlayerLook>();


        //Khi xảy ra event Jump trong Input Actions (phím Space), gọi method Jump() của class PlayerMovement
        playerActions.Jump.performed += ctx => playerMovement.Jump();
        //Khi xảy ra event Crouch trong Input Actions (phím LeftShift), gọi method Crouch() của class PlayerMovement
        playerActions.Crouch.performed += ctx => playerMovement.Crouch();
        //Khi xảy ra event Sprint trong Input Actions (phím LeftCtrl), gọi method Sprint() của class PlayerMovement
        playerActions.Sprint.performed += ctx => playerMovement.Sprint();       
        
    }


    private void FixedUpdate()
    {
        //Truyền giá trị đọc từ Action Movement trong Input Actions vào method PlayerMoveAndMove của class PlayerMovement
        playerMovement.PlayerMoveAndMove(playerActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        //Truyền giá trị đọc từ Action Look trong Input Actions vào method PlayerLookByMouse của class PlayerLook
        playerLook.PlayerLookByMouse(playerActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable() 
    {
        //Kích hoạt các hành động khi component được kích hoạt
        playerActions.Enable();
    }

    private void OnDisable()
    {
        //Tắt các hành động khi component bị tắt
        playerActions.Disable();
    }
}
