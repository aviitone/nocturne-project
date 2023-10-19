using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactions
{
    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }

    public void TakeDamage()
    {
        Debug.Log("ouch >:(");
    }
}
