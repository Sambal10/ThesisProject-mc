using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class F_PlayerMovement : MonoBehaviour
{
    private Rigidbody characterRB; // Reference to the Rigidbody component of the character

    private Vector3 movementInput; // Stores movement input received from the player
    public Vector3 movementVector; // Stores the resulting movement vector
    [SerializeField] private float movementSpeed; // Movement speed of the character

    [Header("Jump")]
    [SerializeField] float jumpForce = 5f;


    void Start()
    {
        characterRB = GetComponent<Rigidbody>(); // Getting the Rigidbody component attached to the character
    }
    private bool IsGrounded()
    {
        return Mathf.Abs(characterRB.velocity.y) < 0.01f; //check if the player is on the ground
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
    void FixedUpdate()
    {
       
        if (movementInput != Vector3.zero)
        {
            // Calculate movement vector based on input and current orientation of the character
            movementVector = transform.right * movementInput.x + transform.forward * movementInput.z;
            movementVector.y = 0; //since we are rotating the entire game object we only want to calculate the movement vector along the x and z axis (ignore the vertical component of movement)
        }

        // Set the velocity of the character's Rigidbody to move it
        characterRB.velocity = (movementVector * Time.fixedDeltaTime * movementSpeed);

    }

    // This method is invoked when there is movement input
    private void OnMovement(InputValue input)
    {
        // Getting movement input values (x and y axes)
        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
    }
    private void OnMovementStop(InputValue input)
    {
        movementVector = Vector3.zero;
    }
    
}
