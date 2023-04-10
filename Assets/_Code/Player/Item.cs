using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour, IItem
{
    public UnityEvent PickedUp;
    public UnityEvent Droped;

    public virtual void PickUp()
    {
        PickedUp.Invoke();
    }

    public virtual void Drop()
    {
        Droped.Invoke();
    }
}
