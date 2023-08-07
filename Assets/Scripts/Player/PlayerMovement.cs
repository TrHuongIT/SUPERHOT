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

    private bool leftCrouch;
    private bool crouching;
    private bool sprinting;
    private float crouchTimer;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = characterController.isGrounded;

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

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        leftCrouch = true;
    }

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
