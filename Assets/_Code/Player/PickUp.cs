using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour, IInteractable
{
    public UnityEvent PickedUp;
    public UnityEvent Droped;

    public virtual void Interact()
    {
        PickedUp.Invoke();
    }

    public virtual void Drop()
    {
        Droped.Invoke();
    }
}
