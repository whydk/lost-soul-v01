using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public GameObject explosionParticle;
    public int damage;
    AudioManager am;
    public string soundName;
    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        am.Play(soundName);
        Instantiate(explosionParticle, transform.position, transform.rotation);
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
