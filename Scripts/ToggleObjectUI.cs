using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectUI : MonoBehaviour
{
    public GameObject uiItem;
    public GameObject crossHair;

    void Start()
    {
        crossHair = GameObject.FindGameObjectWithTag("Crosshair");
    }

    void Update()
    {
        if (!crossHair.activeSelf)
        {
            uiItem.SetActive(false);
        }
    }
}