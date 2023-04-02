using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingDoor : MonoBehaviour
{
    [SerializeField]
    private float playTime;
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
                Invoke("animation",playTime);
            }
        }
    }
}
