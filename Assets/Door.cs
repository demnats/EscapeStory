using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private List<float> angles = new();

    private HingeJoint hingeJoint;
    private JointLimits limits = new();

    private int pushed = 0;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        limits = hingeJoint.limits;
        SetMaxAngle();
    }

    private void SetMaxAngle()
    {
        if (pushed > angles.Count-1)
            return;

        limits.max = angles[pushed];
        hingeJoint.limits = limits;
    }

    public void Interact()
    {
        pushed++;

        SetMaxAngle();

        GetComponent<Rigidbody>().AddForce(-transform.forward * 500);
    }
}
