using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.Mathematics;

public class AngryScale : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] enemyBehaviours;
    [SerializeField] private Renderer renderer;

    [SerializeField] private float angryScale;
    [SerializeField] private float angryScaleMax;
    [SerializeField] private float downScaleTime;
    [SerializeField] private Slider slider;

    [SerializeField] private float addedFollowSpeed;

    private float walkSpeed;

    NavMeshAgent agent;

    private int timer = 0;

    private bool allowMove = true;

    public float Angry { get { return angryScale; } }

    private void Awake()
    {
        foreach(MonoBehaviour behaviour in enemyBehaviours)
        {
            behaviour.enabled = false;
        }
        renderer.enabled = false;

        agent = GetComponent<NavMeshAgent>();
        walkSpeed = agent.speed;
    }

    private void AllowMove(int allow)
    {
        allowMove = allow == 1;

        if(!allowMove)
        {
            agent.speed = 0;
        }
    }

    private void UpdateSlider()
    {
        slider.value = Mathf.InverseLerp(0, angryScaleMax, angryScale);

        if(slider.value > 0.7)
        {
            foreach (MonoBehaviour behaviour in enemyBehaviours)
            {
                behaviour.enabled = true;
            }
            renderer.enabled = true;
        }
    }

    public void AddAngry()
    {
        angryScale++;
        timer = 0;
        UpdateSlider();
    }

    public void AddAmount(float amount)
    {
        angryScale += amount;

        UpdateSlider();
    }

    public void SetScale(float amount)
    {
        angryScale = amount;

        UpdateSlider();
    }

    private void Update()
    {
        timer++;

        if(timer > downScaleTime)
        {
            angryScale--;
            UpdateSlider();
        }

        angryScale = Mathf.Clamp(angryScale, 0, angryScaleMax);

        if (!allowMove)
            return;

        agent.speed = walkSpeed + (slider.value * addedFollowSpeed);
    }

}
