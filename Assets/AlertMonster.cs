using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertMonster : MonoBehaviour
{
    [SerializeField] float alertAmount = 500;

    private void OnTriggerEnter(Collider other)
    {
        AngaryScale scale = other.gameObject.GetComponent<AngaryScale>();

        if (scale != null)
        {
            scale.AddAmount(alertAmount);
        }

        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.HearSound(transform.position);
            Debug.Log(gameObject.name, this.gameObject);
        }
    }
}
