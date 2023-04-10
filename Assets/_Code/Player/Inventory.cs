using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private GameObject holdingItem;

    [SerializeField] private Transform handTransform;

    public GameObject HoldingItem => holdingItem;

    public void PickUp(GameObject item)
    {
        holdingItem = item;

        holdingItem.layer = 2;
        holdingItem.GetComponent<IItem>().PickUp();
        holdingItem.GetComponent<Rigidbody>().isKinematic = true;
        holdingItem.transform.position = handTransform.position;
        holdingItem.transform.SetParent(handTransform);
    }

    public void DropItem()
    {
        if (holdingItem == null)
            return;

        holdingItem.layer = 0;
        holdingItem.transform.SetParent(null);
        holdingItem.GetComponent<IItem>().Drop();
        holdingItem.GetComponent<Rigidbody>().isKinematic = false;

        holdingItem = null;
    }
}

public interface IItem
{
    void PickUp();
    void Drop();
}

public interface IRequire
{
    bool Interact(GameObject gameobject);
}
