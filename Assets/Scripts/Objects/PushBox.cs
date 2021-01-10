using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    public CharacterController controller;
    public new Rigidbody rigidbody;
    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Player"))
        {
            rigidbody.velocity += controller.velocity;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        

        if (other.tag.Equals("Player"))
        {

            rigidbody.velocity += controller.velocity;

        }

    }
    private void OnTriggerExit(Collider other)
    {

    }
}
