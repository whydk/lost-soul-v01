using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public bool changeSide;
    public Transform playerPos;
    public Transform playerHips;
    public bool followPlayer = false;
    public bool playerInRange;

    //Attack
    public GameObject projectile;
    public float projectileSpeed;
    public int attackDamage;

    AudioManager am;


    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        playerHips = GameObject.FindGameObjectWithTag("PlayerHips").transform;
        am = FindObjectOfType<AudioManager>();
    }
    public void ChangeRotationToPlayer()
    {
        Vector3 changeRot = transform.localScale;
        changeRot.z *= 1f;

        if (transform.position.x > playerPos.position.x && changeSide)
        {
            transform.localScale = changeRot;
            transform.Rotate(0f, 180f, 0f);
            changeSide = false;
        }
        else if (transform.position.x < playerPos.position.x && !changeSide)
        {
            transform.localScale = changeRot;
            transform.Rotate(0f, 180f, 0f);
            changeSide = true;
        }
    }
    public void AttackIdle()
    {
        am.Play("Fireball");
        GameObject poison = Instantiate(projectile, transform.localPosition, transform.localRotation);
        poison.transform.parent = null;
        Rigidbody rb = poison.GetComponent<Rigidbody>();
        if (!changeSide)
        {
            poison.transform.position -= new Vector3(2f, -2f, 0f);
        }
        else
        {
            poison.transform.position += new Vector3(2f, 2f, 0f);
        }
        poison.transform.LookAt(playerHips);

        rb.velocity = poison.transform.forward * projectileSpeed;

    }


}
