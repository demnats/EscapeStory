using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FearInteractionPortal : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hide;

    public UnityEvent monsterAnimation;

    private bool playerIsHiding;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerIsHiding = hide.GetComponent<Hide>().hiding;

            if (playerIsHiding)
            {
                print("working");
                monsterAnimation.Invoke();
            }
        }


    }
}
