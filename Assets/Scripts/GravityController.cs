using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private float gravityDirectionX = 0f; // Only X-axis gravity direction
    private float gravityStrength = 9.8f;
    private Rigidbody rb;

    private bool toggle = false;
    public float value = 0f;

    private Vector3 newGravity; // Declare newGravity as a class member variable

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            toggle = !toggle;
            value = toggle ? 1f : -1f;

            ChangeGravity();
        }
    }

    private void FixedUpdate()
    {
        ApplyGravity();
    }

    private void ChangeGravity()
    {
        newGravity = new Vector3(0f, value, 0f); // Assign the value to newGravity
        Physics.gravity = newGravity;
        gravityDirectionX = -gravityDirectionX;
        rb.velocity = Vector3.zero;
    }

    private void ApplyGravity()
    {
        Vector3 gravityDirection = new Vector3(gravityDirectionX, 0f, 0f); // Only X-axis gravity direction
        rb.AddForce(gravityDirection * gravityStrength, ForceMode.Acceleration);
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.down, gravityDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.2f);
    }
}