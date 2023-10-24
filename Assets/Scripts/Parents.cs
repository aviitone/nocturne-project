using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Parents : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
            Transform objectToWarp = transform.GetChild(0);
            objectToWarp.SetParent(null);
            objectToWarp.SetParent(cameraTransform, false);
    }
}