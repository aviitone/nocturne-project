using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterBeanCube : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("I am the bean cube; my beans are delicious :)");
    }
}
