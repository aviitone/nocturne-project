using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    private GameObject grabbedObject;
    private float grabDistance = 3f;
    private float throwForce = 10f;
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
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
                    grabbedObject.transform.SetParent(transform);
                    Transform objectToSize = transform.GetChild(0);
                    objectToSize.SetParent(cameraTransform, false);
                    objectToSize.localScale = Vector3.one;
                    Transform objectToWarp = transform.GetChild(0);
                    objectToWarp.SetParent(null);
                    objectToWarp.SetParent(cameraTransform, false);
                }
            }
            else
            {
                ;
            }
        }
    }
}

