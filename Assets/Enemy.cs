using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent meshAgent;
    private Animator animator;

    [SerializeField]
    private Transform[] wayPoint;
    private int wayPointNumber;

    [SerializeField] Transform target;
    [SerializeField] FieldOfView fieldOfView;

    [SerializeField]
    private float playerLostAfterSeconds = 3;
    private float playerLost = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        meshAgent = GetComponent<NavMeshAgent>();
        fieldOfView = GetComponent<FieldOfView>();

        fieldOfView.seePlayer += SetTarget;
        fieldOfView.unseePlayer += LoseTarget;
    }

    private void Update()
    {
        if(target != null)
        {
            Chasing();
        }
        else
        {
            Search();
        }
    }

    public void NextWaypoint()
    {
        wayPointNumber = Random.Range(0, wayPoint.Length);
    }

    private void Search()
    {
        meshAgent.SetDestination(wayPoint[wayPointNumber].position);
    }

    private void SetTarget(Transform t)
    {
        if(playerLost != 0)
        {
            animator.SetTrigger("SeePlayer");
        }

        target = t;
        playerLost = 0;
    }

    private void LoseTarget()
    {
        playerLost += Time.deltaTime;
        if (playerLost > playerLostAfterSeconds)
        {
            target = null;
            animator.ResetTrigger("SeePlayer");
        }
    }

    private void Chasing()
    {
        meshAgent.SetDestination(target.position);
    }
}
