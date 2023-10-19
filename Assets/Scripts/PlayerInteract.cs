using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;

    //Grab distance (keep hands and tapestop rays seperate)
    [SerializeField]
    private float GrabDistance = 5f;

    [SerializeField]
    private LayerMask mask;
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * GrabDistance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, GrabDistance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactions>() != null)
            {
                Debug.Log(hitInfo.collider.GetComponent<Interactions>().promptMsg);
            }
        }
    }
}
