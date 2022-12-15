using System;
using System.Collections;
using System.Collections.Generic;
using Ekaterina;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAttacked : MonoBehaviour
{
    public Material MonsterMaterial;
    public Animator MonsterAnimator;
    public ParticleSystem MonsterFire;
    
    private void Awake()
    {
        MonsterMaterial.SetColor("_BaseColor", Color.white);
    }

    private void OnParticleCollision(GameObject collision)
    {
        if (collision.CompareTag("Monster"))
        {
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