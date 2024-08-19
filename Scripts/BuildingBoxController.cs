using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingBoxController : MonoBehaviour
{
    [Header("Building Data")]
    public PlayerStructureData buildingData;

    [Header("Box Data")]
    public TextMeshProUGUI dataText;

    void Start()
    {
        dataText.text = buildingData.buildingName;
        dataText.gameObject.SetActive(false);
    }
}