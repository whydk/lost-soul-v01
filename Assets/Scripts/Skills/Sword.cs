using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Collider swordCollider;
    private void Awake()
    {
        swordCollider = GameObject.Find("Sword_Equipped(Clone)").GetComponent<BoxCollider>();
        swordCollider.enabled = false;
    }

}
