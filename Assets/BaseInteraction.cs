using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseInteraction : MonoBehaviour, IInteractable
{
    public UnityEvent Interaction;
    public void Interact()
    {
        Interaction?.Invoke();
    }
}
