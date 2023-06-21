using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityEvent See;
    public UnityEvent Walk;

    private NavMeshAgent meshAgent;
    private Animator animator;

    [SerializeField]
    private Transform[] wayPoint;
    private int wayPointNumber;

    [SerializeField] public Transform target;
    [SerializeField] FieldOfView fieldOfView;

    [SerializeField]
    private float playerLostAfterSeconds = 3;
    private float playerLost = 0;

    public bool FollowingSound = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        meshAgent = GetComponent<NavMeshAgent>();
        fieldOfView = GetComponent<FieldOfView>();

        fieldOfView.seePlayer += SetTarget;
        fieldOfView.unseePlayer += LoseTarget;
    }

    private void Update()
    {
        if (target != null)
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
            See.Invoke();
        }

        target = t;
        playerLost = 0;
    }

    public void LoseTarget()
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
        Walk.Invoke();
    }

    public void HearSound(Vector3 location)
    {
        FollowingSound = true;
        meshAgent.SetDestination(location);
    }
}
