using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent meshAgent;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float viewRadius;
    [SerializeField] private float lookDistance;
    [SerializeField] private GameObject player;

    [SerializeField] private float minAngeryScale, maxAngeryScale;

    private float angeryScale;
    private bool somethingBreaks = false;

    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        meshAgent.speed = walkSpeed;
    }

    void Update()
    {

        Chasing();

        if (somethingBreaks)
        {
            angeryScale++;
        }
    }
    private void Spawn()
    {
        Vector3 distancePlayer = transform.position - player.transform.position;

        /*if (distancePlayer <= lookDistance)
        {
            distancePlayer.Normalize();
        }*/
    }

    private void DeSpawn()
    {

    }


    private void Chasing()
    {

    }
}
