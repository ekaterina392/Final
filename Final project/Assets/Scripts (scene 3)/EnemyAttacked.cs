using System;
using System.Collections;
using System.Collections.Generic;
using Ekaterina;
using UnityEngine;

public class EnemyAttacked : MonoBehaviour
{
    public GameObject Enemy;
    public Animator Zorlik;

    public int Health = 100;
    int Damage = 50;
    
    //Here should go sounds

    public bool InAttackRange = false;
    
    public ParticleSystem enemyFire1;
    //public ParticleSystem enemyFire2;
    //public ParticleSystem enemyFire3;
    //public ParticleSystem enemyFire4;
    //public ParticleSystem enemyFire5;

    //If enemy's health is zero

    private void Update()
    {
        InAttackRange = false;
        
        if (Health <= 0)
        {
            Zorlik.SetBool("dead", true);
            //disable player controller script
            Enemy.GetComponent<Guard>().enabled = false;
            Enemy.GetComponent<PathUtils>().enabled = false;
        }
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
