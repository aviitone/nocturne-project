using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamm : MonoBehaviour
{
    public float sensX;
    public float sensY;

    Transform orientation;

    float rotX;
    float rotY;

    private void Start()
    {
        //hides the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //getting mouse input
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;

        rotY += mouseX;
        rotX -= mouseY;

        //preventing camera from going too far (aka "clamping")
        rotX = Mathf.Clamp(rotX, -90f, 90f);

        // rotating player/head
        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        orientation.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
