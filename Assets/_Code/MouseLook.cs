using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    public float mouseSensitivityX;
    [SerializeField]
    float xRotation = 0f;
    [SerializeField]
    public float mouseSensitivityY;

    public Transform playerBody;

    private bool allowedToLook = true;
    public bool AllowedToLook { set { allowedToLook = value; } }

    void Start()
    {
        CursorState(1);
    }

    public void CursorState(int state)
    {
        Cursor.lockState = (CursorLockMode)state;
    }

    // Update is called once per frame
    void Update()
    {
        if (!allowedToLook)
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
