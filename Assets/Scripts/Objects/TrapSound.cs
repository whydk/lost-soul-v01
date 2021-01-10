using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSound : MonoBehaviour
{
    public AudioClip[] sound;
    public void UpSound()
    {
        GetComponent<AudioSource>().PlayOneShot(sound[0]);
    }
    public void DownSound()
    {
        GetComponent<AudioSource>().PlayOneShot(sound[1]);
    }
}
