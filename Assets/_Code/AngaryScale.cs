using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.Mathematics;

public class AngaryScale : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] enemyBehaviours;
    [SerializeField] private Renderer renderer;

    [SerializeField] private float angryScale;
    [SerializeField] private float angryScaleMax;
    [SerializeField] private float downScaleTime;
    [SerializeField] private Slider slider;

    NavMeshAgent agent;


    private int timer = 0;

    private void Start()
    {
        foreach(MonoBehaviour behaviour in enemyBehaviours)
        {
            behaviour.enabled = false;
        }
        renderer.enabled = false;

        agent = GetComponent<NavMeshAgent>();
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
        agent.speed += angryScale * 0.01f;
        UpdateSlider();
    }

    public void AddAmount(float amount)
    {
        angryScale += amount;

        UpdateSlider();
    }

    private void Update()
    {
        timer++;

        if(timer > downScaleTime)
        {
            angryScale--;
            agent.speed -= angryScale * 0.01f;
            UpdateSlider();
        }

        angryScale = Mathf.Clamp(angryScale, 0, angryScaleMax);
    }
}
