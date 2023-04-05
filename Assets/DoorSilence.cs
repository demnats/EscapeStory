using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorSilence : MonoBehaviour
{
    public Key key;

    public UnityEvent TriggerEnter;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("It is working");
            TriggerEnter.Invoke();
        }
    }
}
