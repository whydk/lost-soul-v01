using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && other.GetComponent<Knockback>().knockBackEnabled == true)
        {
            Debug.Log(gameObject.name + " trigger " + other.name);
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log(gameObject.name + " trigger " + other.name);
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }

    }
}
