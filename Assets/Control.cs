using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private GameObject controlMenu;
    private PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controlMenu.SetActive(false);
            pauseMenu.Resume();
        }
    }
}
