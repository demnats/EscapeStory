using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public UnityEvent Running;

    [SerializeField] private float move;

    private float gravity = -9.81f;

    private float velocity;

    [SerializeField] private float sneakWalkSpeed;
    [SerializeField] private float movementSpeed;

    [SerializeField]
    private CharacterController controller;

    public bool allowedToMove = true;

    public bool AllowedToMove { set { allowedToMove = value; } }

    void Update()
    {
        if (!allowedToMove)
            return;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(!Input.GetKey(KeyCode.LeftShift))
        {
            move = movementSpeed;
            if(z != 0 || x != 0)
            {
                Running.Invoke();
            }
        }
        else
        {
            move = sneakWalkSpeed;
        }

        controller.Move((z * transform.forward + x * transform.right) * move);

        Gravity();
    }

    private void Gravity()
    {
        velocity = gravity * Time.deltaTime;
        controller.Move(new Vector3(0, velocity, 0));
    }
}