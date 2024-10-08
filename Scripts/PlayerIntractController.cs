using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntractController : MonoBehaviour
{
    [Header("Player Data")]
    public PlayerController controller;
    public PlayerBuildController buildController;
    public Camera camera;

    [Header("Interaction")]
    public LayerMask interactableLayers;
    public float raycastLength = Mathf.Infinity;
    public GameObject crossHair;

    void Update()
    {
        // Interact
        RaycastHit hit;
        
        if (Physics.Raycast(controller.camera.transform.position, controller.camera.transform.forward, out hit, raycastLength, interactableLayers) && controller.canLook)
        {
            // Debug Data
            print(hit.collider.gameObject.tag);
            
            // Adjust on Look
            if ((hit.collider.gameObject.layer==6) && controller.canLook)
            {
                crossHair.SetActive(true);
                if (hit.collider.gameObject.GetComponent<ToggleObjectUI>()!=null)
                {
                    hit.collider.gameObject.GetComponent<ToggleObjectUI>().uiItem.SetActive(true);
                }
            } else {
                crossHair.SetActive(false);
            }

            // Get a click
            if (Input.GetMouseButtonDown(0))
            {
                // Item boxes
                if (hit.collider.gameObject.tag=="Box")
                {
                    if (hit.collider.gameObject.GetComponent<BuildingBoxController>()!=null)
                    {
                        buildController.buildings.Add(hit.collider.gameObject.GetComponent<BuildingBoxController>().buildingData);
                        Destroy(hit.collider.gameObject);
                    }
                }

                // Trees
                if (hit.collider.gameObject.tag=="Tree")
                {
                    hit.collider.gameObject.GetComponent<TreeController>().gainWood();
                }

                // Iron Node
                if (hit.collider.gameObject.tag=="Iron")
                {
                    hit.collider.gameObject.GetComponent<IronNodeController>().gainIron();
                }
            }
        } else {
            // Hide crosshair
            crossHair.SetActive(false);
        }
    }
}