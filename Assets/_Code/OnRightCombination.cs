using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnRightCombination : MonoBehaviour, IRequire
{
    public UnityEvent OnCombi;

    public bool rightCombi = false;

    [SerializeField] private Color key;

    public bool Interact(GameObject requiredItem)
    {
        PaintBucket bucket = requiredItem.GetComponent<PaintBucket>();
        if (bucket != null)
        {
            if (bucket.Color == key)
            {
                OnCombi.Invoke();
                rightCombi = true;
            }
        }
        return false;
    }
}
