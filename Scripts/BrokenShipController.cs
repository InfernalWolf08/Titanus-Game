using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrokenShipController : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI uiText;
    public int quartzLeft = 50;
    public int aluminumLeft = 100;
    public int tungstenLeft = 100;
    public int ironLeft = 200;
    public int oilLeft = 500;

    void Start()
    {
        updateResources();
    }

    public void updateResources()
    {
        uiText.text = String.Format("<size=.45>Parts Required to Repair Ship:</size>\n<size=.5>Quartz: {0}\nAluminum: {1}\nTungsten: {2}\nIron: {3}\nOil: {4}", Convert.ToString(quartzLeft), Convert.ToString(aluminumLeft), Convert.ToString(tungstenLeft), Convert.ToString(ironLeft), Convert.ToString(oilLeft));
    }
}