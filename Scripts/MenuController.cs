using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("Other")]
    public GameObject menu;
    public PlayerController player;

    [Header("Tabs")]
    public GameObject Inventory;
    public GameObject Tech;
    public GameObject Skills;
    public GameObject Options;

    [Header("Inventory")]
    public Vector2[] inventory;
    public string[] itemList;
    public Sprite[] itemSprites;
    public Image[] slots;
    public TextMeshProUGUI[] amounts;
    public Sprite noTexture;
    public int id;
    public int maxStack = 999;

    void Start()
    {
        // Initiation
        menu.SetActive(false);

        foreach (TextMeshProUGUI text in amounts)
        {
            text.text = "";
        }
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
                player.canLook = false;
            } else {
                Cursor.lockState = CursorLockMode.Locked;
                player.canLook = true;
            }
        }
    }

    public void addItem(string item)
    {
        // Find the id of the item
        id = Array.IndexOf(itemList, item);

        // Find the most appropriate slot to place the item in
        int nextEmptySlot = 0;
        foreach (Image slot in slots)
        {
            // If the slot is empty, or already has the item
            if (slot.sprite==null || inventory[nextEmptySlot].x==id)
            {
                // If the slot has not yet reached the 999 cap
                if (inventory[nextEmptySlot].y<maxStack)
                {
                    inventory[nextEmptySlot].x = id;
                    inventory[nextEmptySlot].y += 1;

                    // Update amount of item the player has
                    amounts[nextEmptySlot].text = Convert.ToString(inventory[nextEmptySlot].y);
                }

                break;
            }

            // Iterate nextEmptySlot
            nextEmptySlot+=1;
        }

        // Show the items image in that slot
        if (itemSprites[id]!=null)
        {
            slots[nextEmptySlot].sprite = itemSprites[id];
        } else {
            slots[nextEmptySlot].sprite = noTexture;
        }
    }
}