using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Animator DragonAnimator;

    public GameObject Player;
    public int Health = 100;
    int Damage = 10;
    public GameObject HealthDisplay;
    
    //Here should go sounds

    public GameObject EndMenu;
    public bool InAttackRange = false;

    private void Awake()
    {
        EndMenu.SetActive(false);
    }
    
    private void Update()
    {
        if (Health <= 0)
        {
            HealthDisplay.GetComponent<TMP_Text>().text = "" + "0";
            Time.timeScale = 0;
            EndMenu.SetActive(true);
            
            //disable player controller script
            Player.GetComponent<ThirdPersonMovement>().enabled = false;
            
            Cursor.visible = true;
            Screen.lockCursor = false;
        }
    }

    //Enemy hit
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            InAttackRange = true;
            StartCoroutine(HurtPlayer());
            //DragonAnimator.ResetTrigger("idle");
            //DragonAnimator.ResetTrigger("walk");

            DragonAnimator.SetBool("hit1", true);
        }
        
        if (collision.transform.tag == "Cannon")
        {
            InAttackRange = true;
            StartCoroutine(HurtPlayer());
            
            DragonAnimator.SetTrigger("hitFly");
            //DragonAnimator.ResetTrigger("walk");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        //DragonAnimator.ResetTrigger("hit");
        InAttackRange = false;
        DragonAnimator.SetBool("hit1", false);
    }

    IEnumerator HurtPlayer()
    {
        while (true && InAttackRange == true)
        {
            Health -= Damage;
            HealthDisplay.GetComponent<TMP_Text>().text = "" + Health;
            yield return new WaitForSeconds(3f);
        }
    }
}
