using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSearch : MonoBehaviour
{
    EnemyRanged enemy;
    private void Awake()
    {
        enemy = GetComponentInParent<EnemyRanged>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponentInChildren<ChangeLightColor>().changeColor = true;
            enemy.playerInRange = true;
            enemy.followPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.playerInRange = false;
        }
    }
}
