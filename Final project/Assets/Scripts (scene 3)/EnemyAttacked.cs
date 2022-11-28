using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacked : MonoBehaviour
{
    public int Health = 100;
    int Damage = 1;
    
    //Here should go sounds

    public bool InAttackRange = false;
    
    public ParticleSystem enemyFire1;
    //public ParticleSystem enemyFire2;
    //public ParticleSystem enemyFire3;
    //public ParticleSystem enemyFire4;
    //public ParticleSystem enemyFire5;

    //If enemy's health is zero
    
    /*
    private void Update()
    {
        if (Health <= 0)
        {
            Time.timeScale = 0;
        }
    } */

    private void Update()
    {
        InAttackRange = false;
    }

    private void OnParticleCollision(GameObject collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            InAttackRange = true;
            StartCoroutine(HurtEnemy());
            
            //Debug.Log("collision");
            CreateParticles();
        }
    }
    
    IEnumerator HurtEnemy()
    {
        while (true && InAttackRange == true)
        {
            Health -= Damage;
            yield return new WaitForSeconds(3f);
        }
    }

    void CreateParticles()
    {
        enemyFire1.Play();
        //enemyFire2.Play();
        //enemyFire3.Play();
        //enemyFire4.Play();
        //enemyFire5.Play();
    }

}
