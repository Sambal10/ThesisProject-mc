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

    //Jump
    [Header("Jump")]
    [SerializeField] float jumpForce = 5f; //jump strength

    [Header("Crouch")]
    [SerializeField] float crouchspeed = 2f; //crouch speed
    [SerializeField] float crouchHeight = 1f; //crouch height
    [SerializeField] float standHeight = 2f; //stand height
    [SerializeField] Vector3 crouchScale = new Vector3(1, 0.5f, 1); //crouch scale
    [SerializeField] Vector3 standScale = new Vector3(1, 1f, 1); //stand scale
    CapsuleCollider capsuleCollider;
    private bool isCrouching = false; //check if the player is crouching
    private float currentSpeed;

    [Header("Sprint")]
    [SerializeField] float sprintSpeed = 8f; //sprint speed
    private bool isSprinting = false; //check if the player is sprinting


    PlayerInput playerInput;
    InputAction moveAction;
    InputAction jumpAction;
    
    
 
    


    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentSpeed = movementSpeed;
    }
    private void OnSprint(InputValue input)
    {
        isSprinting = input.isPressed; //toggle sprint state

        if (!isCrouching) 
        {
            currentSpeed = isSprinting? sprintSpeed : movementSpeed; //set speed based on sprint state
        }
      
    }
    private void OnCrouch(InputValue input)
    {
        isCrouching = !isCrouching; //toggle crouch state

        if (isCrouching)
        {
            currentSpeed = crouchspeed; //set speed to crouch speed
        }
        else 
        {
            currentSpeed = isSprinting ? sprintSpeed : movementSpeed; //set speed to sprint speed if sprinting, else set to normal speed
        }
        currentSpeed = isCrouching ? crouchspeed : movementSpeed; //set speed based on crouch state

        transform.localScale = isCrouching ? crouchScale : standScale; //set scale based on crouch state

        if (capsuleCollider != null)
        {
            capsuleCollider.height = isCrouching ? crouchHeight : standHeight; //set height based on crouch state
            capsuleCollider.center = new Vector3(0, capsuleCollider.height / 2, 0);
        }

        Debug.Log("crouch toggled:" + isCrouching);
    }
    private bool IsGrounded()
    {
        return Mathf.Abs(characterRB.velocity.y) < 0.01f; //check if the player is on the ground
    }
    private void OnMovement(InputValue input)
    {
        movementInput=input.Get<Vector2>();
    }

    private void OnJump(InputValue input)
    {
        if (IsGrounded())
        {
            characterRB.velocity = new Vector3(characterRB.velocity.x, 0, characterRB.velocity.z); //reset y velocity to 0
            characterRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //apply jump force
            Debug.Log("Jump"); //debug log
        }
    }
    private void ApplyMovement()
    {
        movementVector= playerCamera.forward*movementInput.y+playerCamera.right*movementInput.x;
        movementVector.y = 0;
        transform.position += movementVector * currentSpeed * Time.deltaTime;
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
