using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorSilence : MonoBehaviour
{
    public OnRightCombination rightCobi;
    public UnityEvent TriggerEnter;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && rightCobi.rightCombi)
        {
            print("It is working");
            TriggerEnter.Invoke();
            print("isworking");
        }
    }


}
