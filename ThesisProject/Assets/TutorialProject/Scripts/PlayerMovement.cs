using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody characterRB;
    [SerializeField] Vector3 movementInput;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float movementSpeed;
    [SerializeField] Transform playerCamera;
    

    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
    }

    private void OnMovement(InputValue input)
    {
        movementInput=input.Get<Vector2>();
    }
    private void ApplyMovement()
    {
        movementVector= playerCamera.forward*movementInput.y+playerCamera.right*movementInput.x;
        movementVector.y = 0;
        transform.position += movementVector * movementSpeed * Time.deltaTime;
    }
    void OnMovementStop(InputValue input)
    {
        movementInput = input.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMovement();
    }
}
