using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private List<float> angles = new();

    private HingeJoint hingeJoint;
    private JointLimits limits = new();

    private int pushed = 0;
    private int angeryMeter;

    public UnityEvent openDoor;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        limits = hingeJoint.limits;
        SetMaxAngle();
    }

    private void Update()
    {
        if (angeryMeter > 0)
        {
            openDoor.Invoke();
            angeryMeter--;
        }
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
        angeryMeter += 200;
        SetMaxAngle();

        GetComponent<Rigidbody>().AddForce(-transform.forward * 500);
    }
}
