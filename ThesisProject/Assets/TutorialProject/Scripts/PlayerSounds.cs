using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnMovement(InputValue input)
    {
        audioSource.clip =SoundBank.instance.stepAudio;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void OnMovementStop(InputValue input)
    {
        audioSource.Stop();
        audioSource.loop = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
