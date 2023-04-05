using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool hasRightColor = false;
    private Material material;

    public bool HasRightColor
    {
        get { return hasRightColor; }
        set { hasRightColor = value; }
    }
}
