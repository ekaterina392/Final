using System;
using System.Collections;
using System.Collections.Generic;
using Ekaterina;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAttacked : MonoBehaviour
{
    public Material material;
    public NavMeshAgent _agent;

    public GameObject Enemy;
    public Animator Zorlik;

    public int Health = 100;
    int Damage = 50;
    
    //Here should go sounds

    public bool InAttackRange;
    
    public ParticleSystem enemyFire1;
    //public ParticleSystem enemyFire2;
    //public ParticleSystem enemyFire3;
    //public ParticleSystem enemyFire4;
    //public ParticleSystem enemyFire5;

    //If enemy's health is zero

    //Color green;


    private void Awake()
    {
        material.SetColor("_BaseColor", Color.white);
    }

    private void Update()
    {
        InAttackRange = false;
        
        if (Health <= 0)
        {
            Zorlik.SetBool("dead", true);
            //disable player controller script
            Enemy.GetComponent<Guard>().enabled = false;
            Enemy.GetComponent<PathUtils>().enabled = false;
            _agent.speed = 0f;
            material.SetColor("_BaseColor", Color.grey);
            Destroy(enemyFire1);
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
