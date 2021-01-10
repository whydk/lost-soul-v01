using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public GameObject projectile;
    public float speed;
    // Update is called once per frame
    AudioManager am;
    private void Awake()
    {
        am = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            am.Play("ProjectileLaunch");
            GameObject fireball = Instantiate(projectile, gameObject.transform.localPosition, gameObject.transform.localRotation) as GameObject;
            fireball.transform.parent = null;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            if (gameObject.transform.localRotation.eulerAngles.y == 90)
                fireball.transform.position += new Vector3(1f, 1f, 0f);
            else
                fireball.transform.position -= new Vector3(1f, -1f, 0f);
            rb.velocity = gameObject.transform.forward * speed;

        }
    }
}
