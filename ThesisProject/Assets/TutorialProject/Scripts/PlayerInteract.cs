using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public interface IInteractable
{
    void Interact();
}
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] int range= 150;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnInteract(InputValue input) 
    {
        RaycastHit hit;
        Physics.Raycast(cam.transform.position,Vector3.forward, out hit,range);

        IInteractable interactable = hit.collider.GetComponent<IInteractable>();

        if(interactable!= null)
        {
            interactable.Interact();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
