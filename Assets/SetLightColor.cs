using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLightColor : MonoBehaviour
{
    private Light light;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    public void SetLight(string color)
    {
        Color col;
        ColorUtility.TryParseHtmlString(color, out col);

        light.color = col;
    }
}
