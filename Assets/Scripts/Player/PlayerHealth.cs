using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealh;

    private float flashTime = 0.1f;
    public float flash;
    public float invincible;
    private float invincibleTime;
    public SkinnedMeshRenderer playerMesh;
    public bool canGetHit;

    public GameObject deathParticle;
    PlayerSounds ps;


    private void Start()
    {
        currentHealh = maxHealth;
        canGetHit = true;
        Mathf.Clamp(currentHealh, 0, maxHealth);
        ps = GetComponent<PlayerSounds>();
    }
    private void Update()
    {
        if(invincibleTime > 0)
        {
            invincibleTime -= Time.deltaTime;
            flashTime -= Time.deltaTime;

            
            if(flashTime <= 0)
            {
                playerMesh.enabled = !playerMesh.enabled;

                flashTime = flash;
                canGetHit = false;

            }
            if(invincibleTime < 0)
            {
                playerMesh.enabled = true;
                canGetHit = true;

            }
        }
    }
    public void TakeDamage(int damage)
    {

        if (invincibleTime <= 0)
        {
            currentHealh -= damage;
            ps.PlayerHitSound();


            if (currentHealh <= 0)
            {
                
                Die();
            }
            else
            {
                invincibleTime = invincible;
                playerMesh.enabled = false;
                flashTime = flash;
            }
        }
        else
            return;
    }
    public bool CanPlayerGetHit()
    {
        return canGetHit;
    }
    public void IncreaseHealth()
    {
        currentHealh++;
    }
    public void IncreaseMaxHealth()
    {
        maxHealth++;
        IncreaseHealth();
    }
    public void FullHeal()
    {
        currentHealh = maxHealth;
    }
    public void PlayerInvincible(float time)
    {
        invincibleTime = time;
        if (invincibleTime <= 0)
        {
            invincibleTime = invincible;
            playerMesh.enabled = false;
            flashTime = flash;
        }
    }
    void Die()
    {
        Instantiate(deathParticle, transform.position, transform.rotation);
        Debug.Log("Dead");
        GetComponent<CharacterController>().enabled = false;
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<Animator>().SetBool("Die", true);
        Initiate.Fade("GameOver", Color.black, 1f);
    }
}
