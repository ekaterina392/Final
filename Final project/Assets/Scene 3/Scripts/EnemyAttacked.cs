using System;
using System.Collections;
using System.Collections.Generic;
using Ekaterina;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAttacked : MonoBehaviour
{
    //Monster1
    public AudioSource MonsterSound1;
    public AudioSource EnemyFireSound1;
    public Collider Monster1Collider;
    public Material Monster1Material;
    public NavMeshAgent Monster1Agent;
    public GameObject Monster1;
    public Animator Monster1Animator;
    public ParticleSystem Monster1Fire;
    public int Health1 = 100;
    
    int Damage = 2;
    public bool InAttackRange;
    
    private void Awake()
    {
        //Monster1
        Monster1Material.SetColor("_BaseColor", Color.white);
    }

    private void Update()
    {
        InAttackRange = false;
        
        //Monster1
        if (Health1 <= 0)
        {
            Monster1Animator.SetBool("dead", true);
            Monster1.GetComponent<Guard>().enabled = false;
            Monster1.GetComponent<PathUtils>().enabled = false;
            Monster1Agent.speed = 0f;
            Monster1Material.SetColor("_BaseColor", Color.grey);
            Destroy(Monster1Fire);
            Destroy(MonsterSound1);
            Monster1Collider.enabled = false;
        }
    }

    private void OnParticleCollision(GameObject collision)
    {
        //Monster1
        if (collision.CompareTag("Monster1"))
        {
            EnemyFireSound1.Play();
            InAttackRange = true;
            StartCoroutine(HurtEnemy());
            CreateParticlesMonster1();
            
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                StopParticlesMonster1();
                EnemyFireSound1.Stop();
            }
            StartCoroutine(ExecuteAfterTime(10));
        }
    }
    
    IEnumerator HurtEnemy()
    {
        while (true && InAttackRange == true)
        {
            Health1 -= Damage;
            yield return new WaitForSeconds(3f);
        }
    }

    //Monster1
    void CreateParticlesMonster1()
    {
        Monster1Fire.Play();
    }
    
    void StopParticlesMonster1()
    {
        Monster1Fire.Stop();
    }


}
