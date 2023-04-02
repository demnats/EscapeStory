using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    [SerializeField] private GameObject collisonObject;
    private int timer;

    private void Start()
    {
        myMaterial.color = Color.gray;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == collisonObject)
        {
            print(myMaterial.color);
            myMaterial.color = Color.red;
            SetObjectOff();
        }
    }

    private void Respawn()
    {

    }
    private void SetObjectOff()
    {
        collisonObject.SetActive(false);
        timer++;

        if (timer => 30 )
        {

        }
    }
}
