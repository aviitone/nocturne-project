using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamm2 : MonoBehaviour
{
    public float mouseSens = 100f;

    public Transform playerBody;

    float xRot = 0f;
    private void Start()
    {
        //hides the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //getting mouse input
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * mouseSens;
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * mouseSens;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
