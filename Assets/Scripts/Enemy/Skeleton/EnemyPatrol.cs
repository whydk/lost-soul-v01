using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float wanderTime;
    public List<Vector3> wanderPositions;
    public Vector3 currentPosition;
    Rigidbody enemyRb;
    public bool changeSide;

    public Transform playerPos;

    //Attack settings
    public int attackDamage;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        currentPosition = transform.position;
        enemyRb = GetComponent<Rigidbody>();
        CalculateWanderPositions();
    }
    public void CalculateWanderPositions()
    {
        wanderPositions.Add(new Vector3(currentPosition.x + 5f, currentPosition.y));
        wanderPositions.Add(new Vector3(currentPosition.x - 5f, currentPosition.y));
    }
    //Points to player when walking
    public void ChangeRotationPosition(Vector3 position)
    {
        Vector3 changeRot = transform.localScale;
        changeRot.z *= 1f;

        if (transform.position.x > position.x && changeSide)
        {
            transform.localScale = changeRot;
            transform.Rotate(0f, 180f, 0f);
            changeSide = false;
        }
        else if (transform.position.x < position.x && !changeSide)
        {
            transform.localScale = changeRot;
            transform.Rotate(0f, 180f, 0f);
            changeSide = true;
        }
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
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider[] colliderInfo = Physics.OverlapSphere(pos, attackRange, attackMask);
        if (colliderInfo != null)
        {
            foreach (Collider collider in colliderInfo)
            {
                collider.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }

        }
    }
}

