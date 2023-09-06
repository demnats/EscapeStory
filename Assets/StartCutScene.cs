using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutScene : MonoBehaviour
{
    [SerializeField] public CanvasGroup canvasGroup;
    [SerializeField] private float fadingSpeedMax, fadingSpeedMin;

    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject canvas;


    private float timerPush;
    [SerializeField] private float timerMin = 0.3f;
    private float timeBases = 0;
    private bool fadeIn = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && fadeIn)
        {
            FadeIn();
            print("Mworking");
            print(canvasGroup.alpha);
            timerPush++;
        }

        if (timerPush > 0)
        {
            timerPush -= timerMin;
        }
        else
        {
            timerPush = timeBases;
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
}
