using System;
using System.Collections;
using System.Collections.Generic;
using Ekaterina;
using UnityEngine;
using UnityEngine.AI;


public class MonsterAttacked : MonoBehaviour
{
    //Monster1
    //public Collider Monster1Collider;
    public Material MonsterMaterial;
    //public NavMeshAgent Monster1Agent;

    //public GameObject Monster1;
    public Animator MonsterAnimator;
    public ParticleSystem MonsterFire;
    
    //public int Health = 100;
    
    //int Damage = 1;
    
    //Here should go sounds

    //public bool InAttackRange;
    


    private void Awake()
    {
        MonsterMaterial.SetColor("_BaseColor", Color.white);
    }

    /*
    private void Update()
    {
        if (Health <= 0)
        {
            Monster1Animator.SetBool("dead", true);
            //disable player controller script
            //Monster1.GetComponent<Guard>().enabled = false;
            //Monster1.GetComponent<PathUtils>().enabled = false;
            //Monster1Agent.speed = 0f;
            Monster1Material.SetColor("_BaseColor", Color.grey);
            Destroy(Monster1Fire);

            //Collider
            //Monster1Collider.enabled = false;
        }
    } */

    private void OnParticleCollision(GameObject collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Debug.Log("COLLISION");
            
            //InAttackRange = true;
            //StartCoroutine(HurtEnemy());
            
            MonsterMaterial.SetColor("_BaseColor", Color.grey);
            CreateParticlesMonster();
            
            //After ... seconds pass
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                
                MonsterAnimator.SetTrigger("dead 0");
            }
            
            StartCoroutine(ExecuteAfterTime(2));

        }
    }

    void CreateParticlesMonster()
    {
        MonsterFire.Play();
    }
}
