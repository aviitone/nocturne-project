using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    [Header("Var Stuff :)")]
    [SerializeField] private LayerMask HandMask;
    [SerializeField] private Camera PlrCam;
    [SerializeField] public Transform HandTarget;
    [Space]
    [SerializeField] private float PickupRange;

    private Rigidbody CurrentObj;
    private bool IsHolding;

    private Rigidbody rb;
    private void Start()
    {
        IsHolding = false;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicky Click");
            if (CurrentObj)
            {
                Debug.Log("CurrentObj?");
                CurrentObj.useGravity = true;
                CurrentObj = null;
                return;
            }

            Ray CameraRay = PlrCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(CameraRay, out RaycastHit Hitinfo, PickupRange, HandMask))
            {
                CurrentObj = Hitinfo.rigidbody;
                if (CurrentObj != null)
                {
                    if (CompareTag("HandTarget"))
                    {
                        // Stop the cube from moving
                        rb.velocity = Vector3.zero;

                        // Parent the object to the HandTarget
                        transform.SetParent(HandTarget);

                        // Optionally, you can reset the object's position
                        transform.localPosition = Vector3.zero;

                        // Optionally, you can reset the object's position and rotation
                        transform.localPosition = Vector3.zero;
                        transform.localRotation = Quaternion.identity;

                        GameObject hitObject = Hitinfo.transform.gameObject;
                        Debug.Log("Hit object name" + hitObject.name);
                        CurrentObj.useGravity = false;
                    }
                }
            }
        }
        else
        {
            ;
        }
    }

    private void FixedUpdate()
    {
        if (CurrentObj)
        {
            Vector3 DirectionToPoint = HandTarget.position - CurrentObj.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            // Apply a force towards the hand target
            CurrentObj.AddForce(DirectionToPoint.normalized * 1000f, ForceMode.Force);

            // Adjust the rotation to face the hand target
            Quaternion targetRotation = Quaternion.LookRotation(DirectionToPoint, Vector3.up);
            CurrentObj.MoveRotation(Quaternion.RotateTowards(CurrentObj.rotation, targetRotation, 10f));
        }
    }
}

