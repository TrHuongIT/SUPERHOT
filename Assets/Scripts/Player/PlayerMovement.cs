using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField]private Vector3 playerVelocityDirection;
    private float speed = 5f;

    private bool isGrounded;
    private float gravity = -9.8f;

    private float jumpHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = characterController.isGrounded;
    }

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

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocityDirection.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            Debug.Log(playerVelocityDirection.y);
        }
    }
}
