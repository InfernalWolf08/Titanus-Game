using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemNameController : MonoBehaviour
{
    public GameObject identifier;
    public TextMeshProUGUI identifierText;

    public void showItemName()
    {
        identifier.transform.position = Input.mousePosition;
        identifier.SetActive(true);
        identifierText.text = transform.GetChild(1).GetComponent<Image>().sprite.name;
    }

    public void hideItemName()
    {
        identifier.SetActive(false);
    }
}