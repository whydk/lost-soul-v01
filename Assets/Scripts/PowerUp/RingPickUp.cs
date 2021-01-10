using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPickUp : MonoBehaviour
{
    public GameObject ball;
    public float speed;
    AudioManager am;
    public GameObject enableUI;
    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            am.Play("PowerUp");
            other.gameObject.AddComponent<ProjectileSpawn>();
            other.gameObject.GetComponent<ProjectileSpawn>().projectile = ball;
            other.gameObject.GetComponent<ProjectileSpawn>().speed = speed;
            enableUI.SetActive(true);
            Destroy(gameObject);
        }
    }
}
