using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartCutScene : MonoBehaviour
{
    [SerializeField] public CanvasGroup canvasGroup;
    [SerializeField] private float fadingSpeedMax, fadingSpeedMin;

    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject canvas;
    [SerializeField] private float waitSeconds;

    public UnityEvent soundEffect;

    [SerializeField] private float timerMin = 0.3f;
    private bool fadeIn = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && fadeIn)
        {
            StartCoroutine(PressTime());
        }


        if (canvasGroup.alpha <= 0)
        {
            FadeOut();
        }
    }

    private void FadeIn()
    {
        canvasGroup.alpha -= Time.deltaTime * fadingSpeedMax;
    }

    private void FadeOut()
    {
        canvasGroup.alpha += Time.deltaTime * fadingSpeedMin;
        fadeIn = false;
        
        if(fadeIn!)
        {
            fadeIn = true;
        }
    }

    IEnumerator PressTime()
    {
        FadeIn();
        print("Mworking");
        print(canvasGroup.alpha);
        yield return new WaitForSeconds(waitSeconds);
        soundEffect.Invoke();
    }
}
