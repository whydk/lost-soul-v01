using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    new ParticleSystem particleSystem;
    MeshRenderer mesh;
    private void Awake()
    {
        particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        mesh = gameObject.GetComponent<MeshRenderer>();
    }
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            particleSystem.Play();
            
            mesh.enabled = false;
            Destroy(gameObject,3f);

        }
    }

}
