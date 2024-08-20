using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [Header("Menu")]
    public GameObject menu;

    [Header("Tabs")]
    public GameObject Inventory;
    public GameObject Tech;
    public GameObject Skills;
    public GameObject Options;

    [Header("Inventory")]
    public Sprite[] itemSprites;

    void Start()
    {
        // Initiation
        menu.SetActive(false);
    }

    void Update()
    {
        // Toggling
        if (Input.GetKeyDown("escape"))
        {
            menu.SetActive(!menu.activeSelf);

            if (menu.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
            } else {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}