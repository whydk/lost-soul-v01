using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPowerUp : MonoBehaviour
{
    AudioManager am;
    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponent<PlayerHealth>().currentHealh != other.GetComponent<PlayerHealth>().maxHealth)
            {
                am.Play("PowerUp");
                other.GetComponent<PlayerHealth>().IncreaseHealth();
                Debug.Log("Health increased");
                Destroy(gameObject);
            }
        }
    }
}
