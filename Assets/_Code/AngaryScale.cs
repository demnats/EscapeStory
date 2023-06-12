using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class AngaryScale : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] enemyBehaviours;
    [SerializeField] private Renderer renderer;

    [SerializeField] private float angryScale;
    [SerializeField] private float angryScaleMax;
    [SerializeField] private float downScaleTime;
    [SerializeField] private Slider slider;

    private int timer = 0;

    private void Start()
    {
        foreach(MonoBehaviour behaviour in enemyBehaviours)
        {
            behaviour.enabled = false;
        }
        renderer.enabled = false;
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

    private void Update()
    {
        timer++;

        if(timer > downScaleTime)
        {
            angryScale--;
            UpdateSlider();
        }

        angryScale = Mathf.Clamp(angryScale, 0, angryScaleMax);
    }
}
