using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    private GameObject grabbedObject;
    private float grabDistance = 3f;
    private float throwForce = 10f;
    private Transform cameraTransform;
    private Transform handPoint;
    private bool isHoldingObject = false;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        handPoint = cameraTransform.Find("HandPoint");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (grabbedObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance) && hit.collider.CompareTag("OBJ"))
                {
                    grabbedObject = hit.collider.gameObject;
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                    grabbedObject.transform.SetParent(handPoint);
                    grabbedObject.transform.localPosition = Vector3.zero;
                    grabbedObject.transform.localScale = Vector3.one;
                    grabbedObject.transform.localRotation = Quaternion.identity;
                    isHoldingObject = true;
                }
            }
        }
        else
        {
            if (isHoldingObject && Input.GetMouseButtonUp(0))
            {
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * throwForce, ForceMode.Impulse);
                grabbedObject = null;
                isHoldingObject = false;
            }
        }
    }
}