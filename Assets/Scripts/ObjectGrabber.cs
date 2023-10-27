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

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        handPoint = cameraTransform.Find("HandPoint");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbedObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance))
                {
                    grabbedObject = hit.collider.gameObject;
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                    grabbedObject.transform.SetParent(handPoint, true);
                    grabbedObject.transform.localPosition = Vector3.zero;
                    grabbedObject.transform.localScale = Vector3.one;
                    grabbedObject.transform.localRotation = handPoint.localRotation;
                }
            }
            else
            {
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * throwForce, ForceMode.Impulse);
                grabbedObject = null;
            }
        }
    }
}