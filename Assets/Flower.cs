using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private Material material;

    public Color Color
    {
        get => material.color;
    }

    private void Start()
    {
        material = GetComponent<Renderer>().sharedMaterial;
    }
}
