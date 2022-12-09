using System;
using System.Collections;
using System.Collections.Generic;
using Ekaterina;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAttacked : MonoBehaviour
{
    //Mosnter1
    public Material Monster1Material;
    public NavMeshAgent Monster1Agent;

    public GameObject Monster1;
    public Animator Monster1Animator;
    public ParticleSystem Monster1Fire;
    
    public int Health = 100;
    
    int Damage = 1;
    
    //Here should go sounds

    public bool InAttackRange;
    


    private void Awake()
    {
        Monster1Material.SetColor("_BaseColor", Color.white);
    }

    private void Update()
    {
        InAttackRange = false;
        
        if (Health <= 0)
        {
            Monster1Animator.SetBool("dead", true);
            //disable player controller script
            Monster1.GetComponent<Guard>().enabled = false;
            Monster1.GetComponent<PathUtils>().enabled = false;
            Monster1Agent.speed = 0f;
            Monster1Material.SetColor("_BaseColor", Color.grey);
            Destroy(Monster1Fire);
        }
    }

    private void OnParticleCollision(GameObject collision)
    {
        if (collision.CompareTag("Monster1"))
        {
            InAttackRange = true;
            StartCoroutine(HurtEnemy());
            
            //Debug.Log("collision");
            CreateParticlesMonster1();
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

    void CreateParticlesMonster1()
    {
        Monster1Fire.Play();
    }

}
