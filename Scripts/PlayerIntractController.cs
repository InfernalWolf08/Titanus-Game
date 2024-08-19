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
            print(hit.collider.gameObject.name);
            
            // Show Crosshair
            crossHair.SetActive((hit.collider.gameObject.layer==6 || hit.collider.gameObject.layer==14) && controller.canLook);

            // Get a click
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.tag=="Box")
                {
                    if (hit.collider.gameObject.GetComponent<BuildingBoxController>()!=null)
                    {
                        buildController.buildings.Add(hit.collider.gameObject.GetComponent<BuildingBoxController>().buildingData);
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        } else {
            // Hide crosshair
            crossHair.SetActive(false);
        }
    }
}
