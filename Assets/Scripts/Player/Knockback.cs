using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public int knockBackIntensity;
    public bool knockBackEnabled;
    public int knockbackDamage;
    private void Awake()
    {
        knockBackEnabled = true;
    }
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Knockback" && knockBackEnabled == true)
        {
            if (gameObject.GetComponent<PlayerHealth>().CanPlayerGetHit())
            {
                Vector3 knockDirection = hit.transform.position - transform.position;
                knockDirection = -knockDirection.normalized;
                knockDirection = new Vector3(knockDirection.x, knockDirection.y, 0);
                GetComponent<CharacterController>().Move(knockDirection * knockBackIntensity);
                GetComponent<PlayerHealth>().TakeDamage(knockbackDamage);
            }
        }
    }
}
