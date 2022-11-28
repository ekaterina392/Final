using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 100;
    int Damage = 10;
    
    //Here should go sounds

    public bool InAttackRange = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Fire")
        {
            InAttackRange = true;
            StartCoroutine(HurtEnemy());
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        InAttackRange = false;
    }

    IEnumerator HurtEnemy()
    {
        while (true && InAttackRange == true)
        {
            Health -= Damage;
            yield return new WaitForSeconds(3f);
        }
    }

    private void Update()
    {
        if (Health <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
