using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickUp : MonoBehaviour
{
    public GameObject swordObject;
    AudioManager am;
    public GameObject enableUI;
    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            am.Play("PowerUp");
            Instantiate(swordObject, GameObject.Find("RightHand").transform);
            other.gameObject.AddComponent<Sword>();
            other.gameObject.GetComponent<PlayerControl>().hasSword = true;
            other.gameObject.GetComponent<PlayerControl>().attackCollider = other.gameObject.GetComponent<Sword>().swordCollider;
            enableUI.SetActive(true);
            Destroy(gameObject);
        }
    }
}
