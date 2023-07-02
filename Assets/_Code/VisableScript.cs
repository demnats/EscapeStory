using UnityEngine;
using UnityEngine.Events;
public class VisableScript : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    [SerializeField] private GameObject player;

    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            gameObject.SetActive(true);
        }
    }
}
