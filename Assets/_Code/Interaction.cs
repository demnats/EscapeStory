using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float distance = 1f;

    [SerializeField] private Inventory inventory;

    [SerializeField] LayerMask mask;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
    }

    public void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance, mask))
        {

            IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }

            IItem item = hit.collider.gameObject.GetComponent<IItem>();
            if (item != null)
            {
                inventory.PickUp(hit.collider.gameObject);
            }

            IRequire requiredIteractable = hit.collider.gameObject.GetComponent<IRequire>();
            if (requiredIteractable != null)
            {
                if (requiredIteractable.Interact(inventory.HoldingItem))
                {
                    inventory.DropItem();
                }
            }
        }
    }

    private void Drop()
    {
        inventory.DropItem();
    }
}

public interface IInteractable
{
    void Interact();
}
