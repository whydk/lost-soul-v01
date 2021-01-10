using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Health Settings
    public int health;
    public bool invincible = false;
    public bool isBoss = false;
    public GameObject deathParticle;
    public Collider knockback;
    public Collider enemyCollider;
    public string hitSound;
    public string deathSound;
    public void TakeDamage(int damage)
    {
        
        //If invincible dont do damage
        if (invincible)
            return;
        health -= damage;
        FindObjectOfType<AudioManager>().Play(hitSound);
        //Check if boss
        if (isBoss)
        {
            //ChangeState when on 2hp or lower to melee
            if (health <= 2)
            {
                GetComponent<Animator>().SetBool("Walking State", true);
            }
        }
        //If dead then Die
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GetComponent<Animator>().SetBool("Die",true);
        knockback.enabled = false;
        enemyCollider.enabled = false;
        Instantiate(deathParticle, transform.position, deathParticle.transform.rotation);
        FindObjectOfType<AudioManager>().Play(deathSound);
        GetComponentInChildren<Light>().enabled = false;
        if (isBoss)
        {
            Initiate.Fade("Menu", Color.white, 0.1f);
        }
        Destroy(gameObject,2f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Attack"))
        {
            TakeDamage(1);
        }
    }
}
