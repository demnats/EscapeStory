using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float move;

    private float gravity = -9.81f;

    private float velocity;

    [SerializeField] private float sneakWalkSpeed;
    [SerializeField] private float movementSpeed;

    [SerializeField]
    private CharacterController controller;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = Input.GetKey(KeyCode.LeftShift) ? sneakWalkSpeed : movementSpeed;

        controller.Move((z * transform.forward + x * transform.right) * move);

        Gravity();
    }

    private void Gravity()
    {
        velocity = gravity * Time.deltaTime;
        controller.Move(new Vector3(0, velocity, 0));
    }
}