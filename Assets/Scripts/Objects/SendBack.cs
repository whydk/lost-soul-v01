using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendBack : MonoBehaviour
{
    public Vector3 coordinates;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = coordinates;
            other.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = coordinates;
        }
    }
}
