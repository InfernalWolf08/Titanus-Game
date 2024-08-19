using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectUI : MonoBehaviour
{
    public GameObject uiItem;

    public void toggle(bool on)
    {
        uiItem.SetActive(on);
    }
}