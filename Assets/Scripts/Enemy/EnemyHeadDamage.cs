using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadDamage : MonoBehaviour
{
    public int damage;

    EnemyHealth enemy;
    Rigidbody rb;

    private void Awake()
    {
        enemy = transform.parent.GetComponent<EnemyHealth>();
        rb = transform.parent.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enemy.TakeDamage(damage);
            rb.MovePosition(new Vector3(transform.parent.position.x-1, transform.parent.position.y, 0));
        }
    }
}
