using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody characterRB;
    [SerializeField] Vector3 movementInput;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
    }

    private void OnMovement(InputValue input)
    {
        if
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
