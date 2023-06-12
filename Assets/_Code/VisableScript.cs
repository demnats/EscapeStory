using UnityEngine;
using UnityEngine.Events;
public class VisableScript : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;

    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter()
    {
        gameObject.SetActive(true);
    }
}
