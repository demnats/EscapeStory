using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HittingDoor : MonoBehaviour
{
    public UnityEvent triggerClick;

    [SerializeField]
    private float timesHaveToHit;

    private float hitDoorCounter;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            hitDoorCounter ++;
            if (hitDoorCounter > timesHaveToHit)
            {
                triggerClick.Invoke();
            }
        }
    }
}
