using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField]
    public UnityEvent Events;
    public void Interact()
    {
        Events.Invoke();
        print("ola");
    }
}
