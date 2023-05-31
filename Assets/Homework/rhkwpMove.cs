using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rhkwpMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] Animator anim;
    private CharacterController controller;
    public Vector3 moveDir;
    private float ySpeed = 0;
    

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        //controller.Move(moveDir * moveSpeed * Time.deltaTime);
        controller.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);
        controller.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);
        anim.SetFloat("walk", Int());
    }
    private int Int()
    {
        if(Mathf.Abs(moveDir.x) > 0 || Mathf.Abs(moveDir.z) > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir = new Vector3(input.x, 0, input.y);
    }

    private void Jump()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (GroundCheck() && ySpeed < 0)
        {
            ySpeed = -1;
        }
        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void OnJump(InputValue value)
    {
        ySpeed = jumpSpeed;
    }

    private bool GroundCheck()
    {
        RaycastHit hit;
        return Physics.SphereCast(transform.position + Vector3.up * 1, 0.5f, Vector3.down, out hit, 0.6f);
    }
}
