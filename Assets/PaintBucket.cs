using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBucket : MonoBehaviour
{
    [SerializeField] private Color startColor;

    private Material material;

    private bool colorSet = false;

    public Color Color
    {
        get => material.color;
    }

    private void Start()
    {
        material = GetComponent<Renderer>().sharedMaterial;
        material.color = startColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        Flower flower = other.GetComponent<Flower>();
        if (flower != null)
        {
            if(colorSet)
            {
                MixColor(flower.Color);
            }
            else
            {
                colorSet = true;
                ChangeColor(flower.Color);
            }
            other.gameObject.SetActive(false);
            RespawnFlowers();
        }
    }

    private void MixColor(Color color)
    {
        material.color += color;
    }

    private void RespawnFlowers()
    {

    }

    public void ChangeColor(Color color)
    {
        material.color = color;
    }
}
