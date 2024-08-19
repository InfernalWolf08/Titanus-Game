using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildController : MonoBehaviour
{
    [Header("Building")]
    public List<PlayerStructureData> buildings = new List<PlayerStructureData>();
    public PlayerStructureData selectedBuilding;
    public int index;
    public Transform buildingPlacePos;
    public bool building;
    public GameObject placer;

    void Update()
    {
        // Change selected building
        if (buildings.Count>0)
        {
            index += Convert.ToInt32(Input.mouseScrollDelta.y);
            
            if (index<=-1)
            {
                index = buildings.Count-1;
            }

            if (index>buildings.Count-1)
            {
                index = 0;
            }
        }

        // Build
        if (Input.GetKeyDown("b") && !building)
        {
            // Spawn Placer
            building = true;
            selectedBuilding = buildings[index];
            Instantiate(selectedBuilding.buildingPlacer, buildingPlacePos.position, Quaternion.identity, buildingPlacePos);
            placer = GameObject.FindGameObjectWithTag("Placer");
        } else if (Input.GetKeyDown("b") && building) {
            // Destroy Placer
            building = false;
            selectedBuilding = null;
            Destroy(placer);
        }

        // Place Building
    }
}