using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlButton : MonoBehaviour
{
    [SerializeField] private GameObject controlMenu;
    [SerializeField] private GameObject menu;

    public void Controlls()
    {
        controlMenu.SetActive(true);
        menu.gameObject.SetActive(false);
    }
}
