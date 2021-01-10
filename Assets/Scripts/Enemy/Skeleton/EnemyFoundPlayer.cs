using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFoundPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<ChangeLightColor>().changeColor = true;
            transform.parent.GetComponent<Animator>().SetBool("Walk", false);
            transform.parent.GetComponent<Animator>().SetBool("Run", true);
        }
    }
}
