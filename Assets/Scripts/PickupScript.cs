using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    [Header("Var Stuff :)")]
    [SerializeField] private LayerMask HandMask;
    [SerializeField] private Camera PlrCam;
    [SerializeField] private Transform HandTarget;
    [Space]
    [SerializeField] private float PickupRange;

    private Rigidbody CurrentObj;
    private bool IsHolding;
    private void Start()
    {
        IsHolding = false;
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
                    GameObject hitObject = Hitinfo.transform.gameObject;
                    Debug.Log("Hit object name" + hitObject.name);
                    CurrentObj.useGravity = false;
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
        if(CurrentObj)
        {
            Vector3 DirectionToPoint = HandTarget.position - CurrentObj.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObj.velocity = -DirectionToPoint.normalized * 0.1f * DistanceToPoint;
            CurrentObj.transform.LookAt(HandTarget);

            CurrentObj.velocity = CurrentObj.transform.forward * 5f;
        }
    }
}
