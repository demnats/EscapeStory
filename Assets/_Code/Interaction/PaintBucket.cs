using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBucket : MonoBehaviour
{
    [SerializeField] private Color startColor;

    private Material material;

    private bool colorSet = false;

    private float count;

    [SerializeField] public float maxcCount = 150;

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
            //other.gameObject.SetActive(false);
            other.gameObject.GetComponent<Renderer>().enabled = false;
            flower.RespawnFlowers();
        }
    }

    private void Update()
    {
        if (colorSet)
        {
            count++;

            if (count >= maxcCount)
            {
                colorSet = false;
                count = 0;
            }
        }
    }

    private void MixColor(Color color)
    {
        material.color += color;
    }



    public void ChangeColor(Color color)
    {
        material.color = color;
    }
}
