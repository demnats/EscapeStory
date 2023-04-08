using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float distance = 1f;

    private IItem activeItem;

    void Update()
    {
        RaycastHit hit;
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
            {
                //debug
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 5f);
                Debug.Log(hit.collider.gameObject.name);

                IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>(); 
                if(interactable != null)
                {
                    interactable.Interact();
                }

                IItem item = hit.collider.gameObject.GetComponent<IItem>();
                if (item != null)
                {
                    item.PickUp();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (activeItem != null)
            {
                activeItem.Drop();
            }
        }
    }
}

public interface IInteractable
{
    void Interact();
}

public interface IItem
{
    void PickUp();
    void Drop();
}
