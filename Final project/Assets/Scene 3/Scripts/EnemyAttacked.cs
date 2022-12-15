using System;
using System.Collections;
using System.Collections.Generic;
using Ekaterina;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttacked : MonoBehaviour
{
    //Monster1
    public GameObject Destroyed1;
    public AudioSource MonsterSound1;
    public AudioSource EnemyFireSound1;
    public Collider Monster1Collider;
    public Material Monster1Material;
    public NavMeshAgent Monster1Agent;
    public GameObject Monster1;
    public Animator Monster1Animator;
    public ParticleSystem Monster1Fire;
    public int Health1 = 100;
    
    //Monster2
    public GameObject Destroyed2;
    public AudioSource MonsterSound2;
    public AudioSource EnemyFireSound2;
    public Collider Monster2Collider;
    public Material Monster2Material;
    public NavMeshAgent Monster2Agent;
    public GameObject Monster2;
    public Animator Monster2Animator;
    public ParticleSystem Monster2Fire;
    public int Health2 = 100;
    
    //Monster3
    public GameObject Destroyed3;
    public AudioSource MonsterSound3;
    public AudioSource EnemyFireSound3;
    public Collider Monster3Collider;
    public Material Monster3Material;
    public NavMeshAgent Monster3Agent;
    public GameObject Monster3;
    public Animator Monster3Animator;
    public ParticleSystem Monster3Fire;
    public int Health3 = 100;
    
    int Damage = 2;
    public bool InAttackRange;
    
    private void Awake()
    {
        //Monster1
        Monster1Material.SetColor("_BaseColor", Color.white);
        
        //Monster2
        Monster2Material.SetColor("_BaseColor", Color.white);
        
        //Monster3
        Monster3Material.SetColor("_BaseColor", Color.white);
    }

    private void Update()
    {
        InAttackRange = false;
        
        //Monster1
        if (Health1 <= 0)
        {
            Destroy(Destroyed1);
            Monster1Animator.SetBool("dead", true);
            Monster1.GetComponent<Guard>().enabled = false;
            Monster1.GetComponent<PathUtils>().enabled = false;
            Monster1Agent.speed = 0f;
            Monster1Material.SetColor("_BaseColor", Color.grey);
            Destroy(Monster1Fire);
            Destroy(MonsterSound1);
            
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                Monster1Collider.enabled = false;
            }
            StartCoroutine(ExecuteAfterTime(2));
        }
        
        //Monster2
        if (Health2 <= 0)
        {
            Destroy(Destroyed2);
            Monster2Animator.SetBool("dead", true);
            Monster2.GetComponent<Guard>().enabled = false;
            Monster2.GetComponent<PathUtils>().enabled = false;
            Monster2Agent.speed = 0f;
            Monster2Material.SetColor("_BaseColor", Color.grey);
            Destroy(Monster2Fire);
            Destroy(MonsterSound2);
            
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                Monster2Collider.enabled = false;
            }
            StartCoroutine(ExecuteAfterTime(2));        
        }
        
        //Monster3
        if (Health3 <= 0)
        {
            Destroy(Destroyed3);
            Monster3Animator.SetBool("dead", true);
            Monster3.GetComponent<Guard>().enabled = false;
            Monster3.GetComponent<PathUtils>().enabled = false;
            Monster3Agent.speed = 0f;
            Monster3Material.SetColor("_BaseColor", Color.grey);
            Destroy(Monster3Fire);
            Destroy(MonsterSound3);
            
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                Monster3Collider.enabled = false;
            }
            StartCoroutine(ExecuteAfterTime(2));        
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
        
        //Monster2
        if (collision.CompareTag("Monster2"))
        {
            EnemyFireSound2.Play();
            InAttackRange = true;
            StartCoroutine(HurtEnemy2());
            CreateParticlesMonster2();
            
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                StopParticlesMonster2();
                EnemyFireSound2.Stop();
            }
            StartCoroutine(ExecuteAfterTime(10));
        }
        
        //Monster3
        if (collision.CompareTag("Monster3"))
        {
            EnemyFireSound3.Play();
            InAttackRange = true;
            StartCoroutine(HurtEnemy3());
            CreateParticlesMonster3();
            
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                StopParticlesMonster3();
                EnemyFireSound3.Stop();
            }
            StartCoroutine(ExecuteAfterTime(10));
        }
    }
    
    //Monster1
    IEnumerator HurtEnemy()
    {
        while (true && InAttackRange == true)
        {
            Health1 -= Damage;
            yield return new WaitForSeconds(3f);
        }
    }
    
    //Monster2
    IEnumerator HurtEnemy2()
    {
        while (true && InAttackRange == true)
        {
            Health2 -= Damage;
            yield return new WaitForSeconds(3f);
        }
    }
    
    //Monster3
    IEnumerator HurtEnemy3()
    {
        while (true && InAttackRange == true)
        {
            Health3 -= Damage;
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
    
    //Monster2
    void CreateParticlesMonster2()
    {
        Monster2Fire.Play();
    }
    
    void StopParticlesMonster2()
    {
        Monster2Fire.Stop();
    }
    
    //Monster3
    void CreateParticlesMonster3()
    {
        Monster3Fire.Play();
    }
    
    void StopParticlesMonster3()
    {
        Monster3Fire.Stop();
    }
}