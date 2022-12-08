using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

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
        //InAttackRange = false;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

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
        InAttackRange = false;

        if (collision.transform.tag == "Monster1")
        {
            Debug.Log("collision");
            InAttackRange = true;
            StartCoroutine(HurtPlayer());
            //DragonAnimator.ResetTrigger("idle");
            //DragonAnimator.ResetTrigger("walk");
            
            DragonAnimator.SetBool("hit1", true);

            //DragonAnimator.SetTrigger("hit2");
        }
        
        /*
        if (collision.transform.tag == "Projectile" && isGrounded == false)
        {
            InAttackRange = true;
            StartCoroutine(HurtPlayer());
            Destroy(GameObject.FindGameObjectWithTag("Projectile"));

            DragonAnimator.SetTrigger("hitFly");
            //DragonAnimator.ResetTrigger("walk");
        }
        
        if (collision.transform.tag == "Projectile")
        {
            InAttackRange = true;
            StartCoroutine(HurtPlayer());
            Destroy(GameObject.FindGameObjectWithTag("Projectile"));

            DragonAnimator.SetTrigger("hit2");
            //DragonAnimator.ResetTrigger("walk");
        } */
        
    }

    private void OnTriggerExit(Collider collision)
    {
        //DragonAnimator.ResetTrigger("hit2");
        DragonAnimator.ResetTrigger("hitFly");
        InAttackRange = false;
        DragonAnimator.SetBool("hit1", false);
    }
    
    //Projectile hit
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Projectile")
        {
            InAttackRange = true;
            StartCoroutine(HurtPlayer());
            Debug.Log("!");
            
            DragonAnimator.SetTrigger("hit1");
        }
        
        if (collision.transform.tag == "Projectile" && isGrounded == false)
        {
            InAttackRange = true;
            StartCoroutine(HurtPlayer());
            Debug.Log("!");
            
            DragonAnimator.SetTrigger("hitFly");
        }
    }
    
    //Projectile stop hitting
    void OnCollisionExit(Collision collision)
    {
        InAttackRange = false;

        Debug.Log("exit"); 
        Destroy(collision.gameObject);
        
        DragonAnimator.ResetTrigger("hitFly");
        
        //Destroy(GameObject.FindGameObjectWithTag("Projectile"));
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
