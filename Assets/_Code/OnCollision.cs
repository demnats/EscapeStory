using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float forceToCollide = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if(KineticEnergy() > forceToCollide)
        {
            SurfaceManager.SpawnEffect(0, SurfaceEffects.Impact, 1, collision.contacts[0].point, Quaternion.identity);
        }
    }

    private float KineticEnergy()
    {
        // mass in kg, velocity in meters per second, result is joules
        return 0.5f * rb.mass * Mathf.Pow(rb.velocity.magnitude, 2);
    }
}
