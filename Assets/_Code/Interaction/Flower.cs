using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Flower : PickUp
{
    private Material material;

    [SerializeField] private float maxRespawnTime;
    private Vector3 startpostion;

    public UnityEvent used;

    public Color Color
    {
        get => material.color;
    }

    private void Start()
    {
        material = GetComponent<Renderer>().sharedMaterial;
        startpostion = transform.position;
    }

    public void RespawnFlowers()
    {
        StartCoroutine(RespawnCoroutine());
    }

    IEnumerator RespawnCoroutine()
    {
        used.Invoke();
        yield return new WaitForSeconds(maxRespawnTime);
        transform.position = startpostion;
        GetComponent<Renderer>().enabled = true;
    }
}
