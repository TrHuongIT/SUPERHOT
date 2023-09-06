using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DarkSmileMovement : MonoBehaviour
{
    private CharacterController cc;
    private float moveSpeed = 5f;
    private Vector3 moveDirection = Vector3.zero;

    private Vector3 fallDirection;
    private float gravity = 9.8f;
    private bool isGround;

    private bool isSprint;
    private bool isCrawl;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGround = cc.isGrounded;
    }

    public void dsMove(Vector2 input)
    {
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        cc.Move(transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

        if (!isGround)
        {
            fallDirection.y += -gravity * Time.deltaTime;
        }

        cc.Move(fallDirection * Time.deltaTime);

    }

    public void Jump()
    {
        if (isGround)
        {
            fallDirection.y = 7f;
        }
    }

    public void dsSprint()
    {
        isSprint = !isSprint;
        if (isSprint)
        {
            
            moveSpeed = 15f;
        } else
        {
            moveSpeed = 5f;
        }
        
                
    }

    public void dsCrawl()
    {
        isCrawl = !isCrawl;
        if (isCrawl && !isSprint)
        {
            moveSpeed = 3f;
            cc.height = 0f;
        } else
        {
            moveSpeed = 5f;
            cc.height = 2f;
        }
    }
}
