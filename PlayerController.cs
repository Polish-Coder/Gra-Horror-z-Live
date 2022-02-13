using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody RB;
    Transform Cam;

    public float Speed;
    public float Sensitivity;

    float xRotation;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Cam = transform.Find("Camera");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        float VerticalMove = Input.GetAxis("Vertical") * Speed;
        float HorizontalMove = Input.GetAxis("Horizontal") * Speed;
        float MouseX = Input.GetAxis("Mouse X") * Sensitivity;
        float MouseY = Input.GetAxis("Mouse Y") * Sensitivity;

        RB.velocity = transform.right * HorizontalMove + transform.forward * VerticalMove;

        transform.Rotate(transform.up * MouseX);

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        Cam.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}