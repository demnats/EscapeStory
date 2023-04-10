using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBucket : MonoBehaviour, IRequire
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

    public bool Interact(GameObject requiredItem)
    {
        Flower flower = requiredItem.GetComponent<Flower>();
        if (flower != null)
        {
            if (colorSet)
            {
                MixColor(flower.Color);
            }
            else
            {
                colorSet = true;
                ChangeColor(flower.Color);
            }
            flower.transform.SetParent(null);
            requiredItem.layer = 0;
            //other.gameObject.SetActive(false);
            requiredItem.GetComponent<Renderer>().enabled = false;
            flower.RespawnFlowers();
            return true;
        }
        Key key = requiredItem.GetComponent<Key>();
        if(key != null)
        {
            key.SetColor(material.color);
        }

        return false;
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
