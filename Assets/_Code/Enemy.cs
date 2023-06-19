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
    private AngryScale angryScale;

    [SerializeField]
    private Transform[] wayPoint;
    private int wayPointNumber;

    [SerializeField] public Transform target;
    [SerializeField] FieldOfView fieldOfView;

    [SerializeField]
    private float playerLostAfterSeconds = 3;
    private float playerLost = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        meshAgent = GetComponent<NavMeshAgent>();
        fieldOfView = GetComponent<FieldOfView>();
        angryScale = GetComponent<AngryScale>();

        fieldOfView.seePlayer += SetTarget;
        fieldOfView.unseePlayer += LoseTarget;
    }

    private void Update()
    {
        if (target != null)
        {
            Chasing();
            if(angryScale.Angry < 600)
            {
                angryScale.SetScale(600);
            }

        }
        else
        {
            if(meshAgent.remainingDistance < 1)
            {
                NextWaypoint();
                Search();
            }
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
        if(target == null)
        {
            animator.Play("Shout_1");
            See.Invoke();

            print("setT");

            target = t;
        }
        playerLost = 0;
    }

    public void LoseTarget()
    {
        playerLost += Time.deltaTime;
        if (playerLost > playerLostAfterSeconds)
        {
            target = null;
        }
    }

    private void Chasing()
    {
        meshAgent.SetDestination(target.position);
        Walk.Invoke();
    }

    public void HearSound(Vector3 location)
    {
        print("hear");
        meshAgent.SetDestination(location);
    }
}
