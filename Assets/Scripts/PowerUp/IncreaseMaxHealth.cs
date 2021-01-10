using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMaxHealth : MonoBehaviour
{
    AudioManager am;
    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            am.Play("PowerUp");
            other.GetComponent<PlayerHealth>().IncreaseMaxHealth();
            Destroy(gameObject);
        }
    }
}
