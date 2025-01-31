using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] int mouseSensitivity;
    [SerializeField] Transform playerCamera;
    [SerializeField] float xRotation,yRotation;
    float mouseX,mouseY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void OnLook(InputValue input)
    {
        mouseX =input.Get<Vector2>().x;
        mouseY =input.Get<Vector2>().y;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = mouseX * Time.deltaTime*mouseSensitivity;
        mouseY = mouseY * Time.deltaTime*mouseSensitivity;

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation= Mathf.Clamp(xRotation,-35, 40);

        playerCamera.rotation = Quaternion.Euler(xRotation,yRotation,0);
        transform.rotation = playerCamera.rotation;
    }
}
