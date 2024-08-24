using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemNameController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject identifier;
    public TextMeshProUGUI identifierText;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (transform.GetChild(1).GetComponent<Image>().sprite!=null)
        {
            identifierText.text = transform.GetChild(1).GetComponent<Image>().sprite.name;
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        identifierText.text = "";
    }
}