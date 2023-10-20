using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
   public void Interact();
}
public class PlayerInteractions : MonoBehaviour
{
    public Transform InteractSource;

    [SerializeField]
    public float range;

    public bool isInteracting;
    public bool inRange;
    void Start()
    {
        isInteracting = false;
        inRange = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractSource.position, InteractSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, range))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
