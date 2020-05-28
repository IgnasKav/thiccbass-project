using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip footsteps;
    public AudioClip jump;
    public AudioClip slide;
    public AudioClip attack;
    public AudioClip grunt;
    public AudioClip death;
    
    private AudioSource audioScource;

    void Awake()
    {
        audioScource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        audioScource.PlayOneShot(footsteps);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            audioScource.PlayOneShot(jump);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioScource.PlayOneShot(attack);
        }
    }

    private void Slide()
    {
        audioScource.PlayOneShot(slide);
    }

    public void Grunt()
    {
        audioScource.PlayOneShot(grunt);
    }

    public void Death()
    {
        audioScource.PlayOneShot(death);
    }
} 
