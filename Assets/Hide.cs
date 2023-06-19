using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    [SerializeField] private Transform reciever;
    [SerializeField] private  GameObject player;
    [SerializeField] private GameObject enemy;

    private Vector3 startPosition;

    private PlayerMovement movement;
    private CharacterController characterController;
    private FieldOfView enemyView;
    private Enemy enemyMovement;

    private bool hiding = false;

    // Start is called before the first frame update
    void Start()
    {
        movement = player.GetComponent<PlayerMovement>();
        characterController = player.GetComponent<CharacterController>();
        enemyView = enemy.GetComponent<FieldOfView>();
        enemyMovement = enemy.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hiding)
        {
            StopHiding();
        }
    }

    public void Hiding()
    {
        startPosition = player.transform.position;

        movement.enabled = false;
        characterController.enabled = false;
        player.transform.position = reciever.position;

        enemyView.PlayerHiding = true;
        enemyView.canSeePlayer = false;
        enemyMovement.target = null;

        StartCoroutine(GoHide());
    }

    private IEnumerator GoHide()
    {
        yield return new WaitForEndOfFrame();

        hiding = true;
    }

    private void StopHiding()
    {
        player.transform.position = startPosition;

        movement.enabled = true;
        characterController.enabled = true;
        enemyView.PlayerHiding = false;

        hiding = false;
    }
}
