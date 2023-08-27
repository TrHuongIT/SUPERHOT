using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController; //Tạo biến với mục đích tham chiếu đến component CC
    //Tạo 1 biến với kiểu dữ liệu là Vector 3 - đồng thời dùng [SF] để hiển thị nó ra ngoài màn hình
    [SerializeField]private Vector3 playerVelocityDirection; 

    private float speed = 10f; //Tốc độ di chuyển của người chơi

    private bool isGrounded; //Kiểm tra xem người chơi có chạm đất hay không
    private float gravity = -9.8f; //Tự định nghĩa trọng lực với gia tốc trọng trường là -9.8

    private float jumpHeight = 3f; //Lực nhảy của nhân vật

    private bool leftCrouch;
    private bool crouching; //Đang trong trọng thái cúi người
    private bool sprinting; //Đang trong trạng thái chạy nước rút
    private float crouchTimer;
    

    void Start()
    {
        characterController = GetComponent<CharacterController>(); //Tương tác vs CC Compontnt của Object (nếu có)
    }

    
    void Update()
    {
        isGrounded = characterController.isGrounded; //Về cơ bản thì biến isGrounded sẽ có giá trị là true or fall
        //"characterController.isGrounded" là cấu trúc kiểm tra nhân vật có chạm đất hay không

        //Đây là thuật toán trong việc tính toán cúi người (theo Youtuber)
        if (leftCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;

            if (crouching)
            {
                characterController.height = Mathf.Lerp(characterController.height, 1, p);
            } else
            {
                characterController.height = Mathf.Lerp(characterController.height, 2, p);
            }
            
            if (p > 1)
            {
                leftCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    //Xử lý việc di chuyển của nhân vật
    public void PlayerMoveAndMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        characterController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        if (isGrounded && playerVelocityDirection.y < 0) playerVelocityDirection.y = -2f;

        playerVelocityDirection.y += 3 * gravity * Time.deltaTime;
        characterController.Move(playerVelocityDirection * Time.deltaTime);
    }

    //Xử lý việc nhảy của nhân vật
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocityDirection.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            //Debug.Log(playerVelocityDirection.y);
        }
    }

    //Xử lý việc cúi thấp người
    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        leftCrouch = true;
    }

    //Xử lý việc chạy nước rút
    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
        {
            speed = 8f;
        } else
        {
            speed = 5f;
        }
    }
}
