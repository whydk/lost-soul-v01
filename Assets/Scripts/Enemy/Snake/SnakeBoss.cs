using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBoss : MonoBehaviour
{
    //Position settings
    public Transform playerPos;
    public Transform playerHips;
    public bool changeSide = false;

    //Attack settings
    public GameObject projectile;
    public float projectileSpeed;
    public int attackDamage;
    public int walkingAttackDamage;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;


    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        playerHips = GameObject.FindGameObjectWithTag("PlayerHips").transform;
    }

    //Points to player when walking
    public void ChangeRotationToPlayer()
    {
        Vector3 changeRot = transform.localScale;
        changeRot.z *= 1f;

        if(transform.position.x > playerPos.position.x && changeSide)
        {
            transform.localScale = changeRot;
            transform.Rotate(0f, 180f, 0f);
            changeSide = false;
        }
        else if(transform.position.x < playerPos.position.x && !changeSide)
        {
            transform.localScale = changeRot;
            transform.Rotate(0f, 180f, 0f);
            changeSide = true;
        }
    }

    //Simple Attack WhenWalking
    public void AttackWalk()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider[] colliderInfo = Physics.OverlapSphere(pos, attackRange, attackMask);
        if(colliderInfo != null)
        {
            foreach(Collider collider in colliderInfo)
            {
                FindObjectOfType<AudioManager>().Play("SnakeAttack");
                collider.GetComponent<PlayerHealth>().TakeDamage(walkingAttackDamage);
            }
            
        }
    }
    public void AttackIdle()
    {
        
        GameObject poison = Instantiate(projectile, transform.localPosition, transform.localRotation);
        FindObjectOfType<AudioManager>().Play("Fireball");
        poison.transform.parent = null;
        Rigidbody rb = poison.GetComponent<Rigidbody>();
        poison.transform.position -= new Vector3(2f, -2f, 0f);
        poison.transform.LookAt(playerHips);
            
        rb.velocity = poison.transform.forward * projectileSpeed;

    }

}
