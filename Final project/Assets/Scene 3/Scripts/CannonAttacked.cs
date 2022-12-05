using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAttacked : MonoBehaviour
{
    public ParticleSystem Smoke;
    public ParticleSystem Explosion1;
    public GameObject Cannon1Destroyed;
    
    private void Awake()
    {
        Cannon1Destroyed.SetActive(false);
    }
    
    private void OnParticleCollision(GameObject collision)
    {
        if (collision.gameObject.name == "Cannon1")
        {
            Debug.Log("cannon1");
            Destroy(GameObject.FindGameObjectWithTag("Cannon1"));
            CreateParticles();
            Cannon1Destroyed.SetActive(true);
            Destroy(Explosion1);
            CreateSmoke();
        }
    }

    void CreateParticles()
    {
        Explosion1.Play();
    }
    
    void CreateSmoke()
    {
        Smoke.Play();
    }
}
