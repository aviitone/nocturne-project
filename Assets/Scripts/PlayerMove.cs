using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private float moveSpeed = 5f;

    public double height = 1.4f;

    private float JumpLock;

    [SerializeField] public float slideForce;

    [SerializeField] public float sprintSpeed = 2f;
    public bool isSprinting = false;

    Vector3 velocity;
    bool isGrounded;

    new Rigidbody rb;

    private void Start()
    {
        transform.localScale = new Vector3(1, 2, 1);
        JumpLock = 0;
    }
    private void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            // stops non-stop velocity buildup :)
            //cus' that's bad :(

            velocity.y = -2f;
        }

        //MOVE
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (isSprinting == true)
        {
            controller.Move(move * speed * sprintSpeed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        //JUMP (TURNED OFF RIGHT NOW)
        if(Input.GetButtonDown("Jump") && isGrounded && JumpLock == 1)
        {
            Debug.Log("jump!!");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //SPRINT
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

        rb.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);
    }
}
