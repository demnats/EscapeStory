using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawn;
    [SerializeField] private float waitseconds = 3;

    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject playerCamera;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(GotHim(other));
    }

    private IEnumerator GotHim(Collider other)
    {
        if (other.gameObject == player)
        {
            CharacterController charaterController = other.GetComponent<CharacterController>();

            charaterController.enabled = false;

            playerCamera.SetActive(false);
            camera.SetActive(true);

            yield return new WaitForSeconds(waitseconds);

            player.transform.position = respawn.position;

            yield return new WaitForSeconds(2f);

            playerCamera.SetActive(true);
            camera.SetActive(false);

            charaterController.enabled = true;
        }
    }
}
