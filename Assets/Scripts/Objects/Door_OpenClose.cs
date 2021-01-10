using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_OpenClose : MonoBehaviour
{
    public Animator animator;
    bool isOpen;
    public AudioClip[] audioClips;
    AudioSource audioSource;

    void Start()
    {
        isOpen = false;
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isOpen = true;
            animator.SetTrigger("Open");
            audioSource.PlayOneShot(audioClips[0]);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isOpen)
        {
            isOpen = false;
            animator.SetTrigger("Close");
            audioSource.PlayOneShot(audioClips[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
