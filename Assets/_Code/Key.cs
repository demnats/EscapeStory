using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : Item
{
    public UnityEvent RightColor;
    public UnityEvent WrongColor;

    [SerializeField] private Color keyColor;

    private bool hasRightColor = false;

    private Material material;

    public bool HasRightColor
    {
        get { return hasRightColor; }
        set { hasRightColor = value; }
    }

    public void SetColor(Color color)
    {
        //print(color);
        if(color == keyColor)
        {
            //print("trySetColor");
            HasRightColor = true;
            RightColor.Invoke();
        }
        WrongColor.Invoke();
    }
}
