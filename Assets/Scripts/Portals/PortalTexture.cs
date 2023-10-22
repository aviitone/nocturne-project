using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTexture : MonoBehaviour
{
    [Header("Portal Vars")]
    public Camera camB;
    public Material CamMatB;

    private void Start()
    {
        if (camB.targetTexture != null)
        {
            camB.targetTexture.Release();
        }

        camB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CamMatB.mainTexture = camB.targetTexture;
    }
}
