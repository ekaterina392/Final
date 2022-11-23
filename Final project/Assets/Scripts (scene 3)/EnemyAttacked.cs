using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacked : MonoBehaviour
{
    public ParticleSystem enemyFire1;
    public ParticleSystem enemyFire2;
    public ParticleSystem enemyFire3;
    public ParticleSystem enemyFire4;
    public ParticleSystem enemyFire5;


    
    private void OnParticleCollision(GameObject collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("collision");
            CreateParticles();
        }
    }

    void CreateParticles()
    {
        enemyFire1.Play();
        enemyFire2.Play();
        enemyFire3.Play();
        enemyFire4.Play();
        enemyFire5.Play();
    }

}
