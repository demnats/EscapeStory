using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnRightCombination : MonoBehaviour
{
    public UnityEvent OnCombi;

    public bool rightCombi = false;

    [SerializeField] private Color key;

    private void OnTriggerEnter(Collider other)
    {
        PaintBucket bucket = other.GetComponent<PaintBucket>();
        if(bucket != null)
        {
            if (bucket.Color == key)
            {
                OnCombi.Invoke();
                rightCombi = true;
            }
        }
    }
}
