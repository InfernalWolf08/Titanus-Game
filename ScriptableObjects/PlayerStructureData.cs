using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerStructureData", order = 1)]
public class PlayerStructureData : ScriptableObject
{
    public string buildingName;
    public GameObject buildingAsset;
    public GameObject buildingPlacer;
    public Vector3 buildingSize;
}