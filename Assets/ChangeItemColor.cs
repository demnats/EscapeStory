using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeItemColor : MonoBehaviour
{
    private Material material;

    [SerializeField] private Color startColor;

    private void Start()
    {
        material = GetComponent<Renderer>().sharedMaterial;
        material.color = startColor;
    }

    public void ChangeColor(Color color)
    {
        material.color = color;
    }

    public void AddColor(Color color)
    {
        material.color += color;
    }
}
