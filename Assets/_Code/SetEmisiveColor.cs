using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEmisiveColor : MonoBehaviour
{
    private Renderer renderer;
    private Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        renderer = GetComponent<Renderer>();
    }

    public void SetLight(string color)
    {
        Color col;
        ColorUtility.TryParseHtmlString(color, out col);

        mat.color = col;
        mat.SetColor("_Emmision", col);
        mat.EnableKeyword("_EMISSION");

        renderer.material = mat;
    }
}
