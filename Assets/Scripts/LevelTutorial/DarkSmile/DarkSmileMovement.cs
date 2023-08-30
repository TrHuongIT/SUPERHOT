using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSmileMovement : MonoBehaviour
{
    private CharacterController cc;
    private float speed = 5f;
    private Vector3 moveDirection;
    [SerializeField]private Vector3 fallDirection;

    private bool isGround;
    private float gravity = -9.8f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;
    }

    private void Update()
    {
        isGround = cc.isGrounded;
    }

    public void dsMove(Vector2 input)
    {
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        cc.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        if(!isGround)
        {
            fallDirection.y += 3f * gravity * Time.deltaTime;
        }        

        cc.Move(fallDirection * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGround)
        {
            fallDirection.y = 10f;
        }
    }
}
