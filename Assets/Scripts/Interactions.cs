using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactions : MonoBehaviour
{
    public string promptMsg;
    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        //temp empty space to be replaced
        //by other object functions
    }
}
