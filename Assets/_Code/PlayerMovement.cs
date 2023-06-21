using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;
    private bool ShouldCrouch => Input.GetKeyDown(KeyCode.LeftControl) && !duringCrouchAnim && characterController.isGrounded;
    [Header("Crouching Parameters")]

    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standinghHeight = 2f;
    [SerializeField] private float timeToCrouch = 0.25f;
    [SerializeField] private Vector3 crouchCenter = new Vector3(0, 0.5f, 0);
    [SerializeField] private Vector3 standingCenter = new Vector3(0, 0, 0);
    private bool isCrouching;
    private bool duringCrouchAnim;

    public UnityEvent Running ;

    private float move;

    private float gravity = -9.81f;

    private float velocity;

    [SerializeField] private float sneakWalkSpeed;
    [SerializeField] private float movementSpeed;

    [SerializeField]
    private CharacterController characterController;

    public bool allowedToMove = true;

    public bool AllowedToMove { set { allowedToMove = value; } }

    private int runCounter = 0;

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
        HandleCrouch();

        characterController.Move((z * transform.forward + x * transform.right) * move);

        Gravity();
    }

    private void Gravity()
    {
        velocity = gravity * Time.deltaTime;
        characterController.Move(new Vector3(0, velocity, 0));
    }

    private void HandleCrouch()
    {
        if (ShouldCrouch)
            StartCoroutine(CrouchStand());

    }

    private IEnumerator CrouchStand()
    {
        if (isCrouching && Physics.Raycast(playerCamera.transform.position, Vector3.up, 1f))
            yield break;

        duringCrouchAnim = true;

        float timeElapsed = 0;
        float targetHeight = isCrouching ? standinghHeight : crouchHeight;
        float currentHeight = characterController.height;
        Vector3 targetCenter = isCrouching ? standingCenter : crouchCenter;
        Vector3 currentCenter = characterController.center;

        while (timeElapsed < timeToCrouch)
        {
            characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed / timeToCrouch);
            characterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed / timeToCrouch);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        characterController.height = targetHeight;
        characterController.center = targetCenter;

        isCrouching = !isCrouching;

        duringCrouchAnim = false;
    }
}