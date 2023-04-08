using UnityEngine;
using UnityEngine.Events;

public class OnEnter : MonoBehaviour
{
    public UnityEvent Trigger;

    [SerializeField] private string tag;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tag))
        {
            Trigger.Invoke();
        }
    }
}
