using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField] private Transform handTransform;

     private GameObject holdingItem;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }
        if (holdingItem != null) return;
            RaycastHit hit;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity) && hit.collider.CompareTag("PickUpObjects"))
                {
                    holdingItem = hit.transform.gameObject;
                    holdingItem.GetComponent<Rigidbody>().isKinematic = true;
                    hit.transform.position = handTransform.position;
                    hit.transform.SetParent(handTransform);
                }
            }        
    }

    public void DropItem()
    {
        if (holdingItem == null) return;
        holdingItem.transform.SetParent(null);
        holdingItem.GetComponent<Rigidbody>().isKinematic = false;
        holdingItem = null;
    }
}
