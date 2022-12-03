using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAttacked : MonoBehaviour
{
    public ParticleSystem Smoke;
    public ParticleSystem Explosion;
    public GameObject CannonDestroyed;
    
    private void Awake()
    {
        CannonDestroyed.SetActive(false);
    }
    
    private void OnParticleCollision(GameObject collision)
    {
        if (collision.gameObject.name == "Cannon")
        {
            Debug.Log("cannon");
            Destroy(GameObject.FindGameObjectWithTag("Cannon"));
            CreateParticles();
            CannonDestroyed.SetActive(true);
            Destroy(Explosion);
            CreateSmoke();
        }
    }

    void CreateParticles()
    {
        Explosion.Play();
    }
    
    void CreateSmoke()
    {
        Smoke.Play();
    }
}
