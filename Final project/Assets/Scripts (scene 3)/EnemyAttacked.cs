using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacked : MonoBehaviour
{
    public ParticleSystem enemyFire;
    
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
        enemyFire.Play();
    }

}
