using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSmileMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField]private Vector3 velocityDirectionY;

    private float speed = 10f;
    private bool isGround;
    private float jumpPower = 20f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        isGround = characterController.isGrounded;
    }

    public void DSMove(Vector2 input)
    {
        Vector3 direction = Vector3.zero;
        direction.x = input.x;
        direction.z = input.y;

        characterController.Move(transform.TransformDirection(direction) * speed * Time.deltaTime);

        if (!isGround ) 
        {
            velocityDirectionY.y -= 2f;
        }              
        characterController.Move(velocityDirectionY * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGround)
        {
            velocityDirectionY.y = jumpPower;
        }
    }
}
