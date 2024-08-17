using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public CharacterController controller;
    public float speed = 12f;
    public Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpStrength = 10;
    public float fallSpeed = 5;
    public bool isGrounded;
    public Transform groundCheck;

    [Header("Looking Around")]
    public float mouseSensitivity = 100f;
    public Camera camera;
    float xRotation = 0f;
    public bool canLook = true;

    [Header("Interaction")]
    public LayerMask interactableLayers;
    public float raycastLength = Mathf.Infinity;
    public GameObject crossHair;


    void Start()
    {
        // Default Position: Vector3(-28.5,12.75,16.25)
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Move
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right*x+transform.forward*z;
        controller.Move((move+velocity)*speed*Time.deltaTime);
        
        // Jump
        print(Physics.CheckSphere(groundCheck.position, .04f));
        isGrounded = Physics.CheckSphere(groundCheck.position, .04f);

        if (!isGrounded)
        {
            velocity.y = gravity*fallSpeed*Time.deltaTime;
        } else {
            // velocity.y = 0;
        }

        if (isGrounded && Input.GetKeyDown("space"))
        {
            velocity.y = Mathf.Sqrt(jumpStrength*-2*gravity);
        }

        // Camera
        if (canLook)
        {
            // Look
            float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        // Interact
        RaycastHit hit;
        
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, raycastLength, interactableLayers) && canLook)
        {
            // Debug Data
            print(hit.collider.gameObject.name);
            
            // Show Crosshair
            crossHair.SetActive((hit.collider.gameObject.layer==6 || hit.collider.gameObject.layer==14) && canLook);

            // Get a click
            if (Input.GetMouseButtonDown(0))
            {
                
            }
        } else {
            // Hide crosshair
            crossHair.SetActive(false);
        }
    }
}