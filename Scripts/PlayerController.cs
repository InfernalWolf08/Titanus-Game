using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public CharacterController controller;
    public float defaultSpeed = 12f;
    [HideInInspector] public float speed = 12f;
    public Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpStrength = 10;
    public float fallSpeed = 5;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask ground;

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
        Cursor.lockState = CursorLockMode.Locked;
        speed = defaultSpeed;
    }

    void Update()
    {
        // Move
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right*x+transform.forward*z;
        controller.Move((move+velocity)*speed*Time.deltaTime);
        
        // Jump
        isGrounded = Physics.CheckSphere(groundCheck.position, .04f);

        RaycastHit groundDistance;
        if (Physics.Raycast(groundCheck.position, Vector3.down, out groundDistance, Mathf.Infinity))
        {
            // Adjust fallspeed
            if (groundDistance.distance > 2f)
            {
                fallSpeed = 4;
            } else {
                fallSpeed = .009f;
            }

            // Groundcheck
            /*if (groundDistance.distance >= 1 && isGrounded)
            {
                isGrounded = false;
            }*/
        }

        if (!isGrounded)
        {
            velocity.y = gravity*fallSpeed;//*Time.deltaTime;
        } else {
            // velocity.y = 0;
        }

        if (isGrounded && Input.GetKeyDown("space"))
        {
            velocity.y = Mathf.Sqrt(jumpStrength*-2*gravity);
        }

        // Crouch
        if (Input.GetKey("left ctrl"))
        {
            camera.transform.localPosition = new Vector3(0, -0.25f, 0);
            controller.center = new Vector3(0, -0.25f, 0);
            controller.height = 1.5f;
            fallSpeed = 10;
        } else {
            camera.transform.localPosition = new Vector3(0, 0.75f, 0);
            controller.center = new Vector3(0, 0, 0);
            controller.height = 2f;
        }

        // Speed
        if (Input.GetKey("left shift"))
        {
            if (Input.GetKey("left ctrl"))
            {
                speed = defaultSpeed*0.75f;
            } else {
                speed = defaultSpeed*2f;
            }
        } else if (Input.GetKey("left ctrl")) {
            speed = defaultSpeed/2f;
        } else {
            speed = defaultSpeed;
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