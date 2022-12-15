using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAttacked : MonoBehaviour
{
    //Cannon1
    public AudioSource CannonExplosion;
    public ParticleSystem Smoke;
    public ParticleSystem Explosion1;
    public GameObject Cannon1Destroyed;
    
    private void Awake()
    {
        //Cannon1
        Cannon1Destroyed.SetActive(false);
    }
    
    private void OnParticleCollision(GameObject collision)
    {
        //Cannon1
        if (collision.gameObject.name == "Cannon1")
        {
            Debug.Log("cannon1");
            Destroy(GameObject.FindGameObjectWithTag("Cannon1"));
            CreateParticles();
            Cannon1Destroyed.SetActive(true);
            Destroy(Explosion1);
            CannonExplosion.Play();
            CreateSmoke();
        }
    }

    //Cannon1
    void CreateParticles()
    {
        Explosion1.Play();
    }
    
    void CreateSmoke()
    {
        Smoke.Play();
    }
}