using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public AudioSource hitFly;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    public Animator DragonAnimator;
    public GameObject Player;
    public int Health = 100;
    int Damage = 10;
    public GameObject HealthDisplay;
    public GameObject EndMenu;
    public GameObject Instructions;
    public bool InAttackRange = false;
    
    private void Awake()
    {
        EndMenu.SetActive(false);
    }
    
    private void Update()
    {
        if (InAttackRange == true)
        {
            DragonAnimator.ResetTrigger("walk");
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Health <= 0)
        {
            HealthDisplay.GetComponent<TMP_Text>().text = "" + "0";
            Time.timeScale = 0;
            EndMenu.SetActive(true);
            Instructions.SetActive(false);

            //disable player controller script
            Player.GetComponent<ThirdPersonMovement>().enabled = false;
            
            Screen.lockCursor = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Scene 3");
                Time.timeScale = 1;
            }
        }
    }

    //Enemy hit
    private void OnTriggerEnter(Collider collision)
    {
        InAttackRange = false;

        //Monster1
        if (collision.transform.tag == "Monster1")
        {
            hitFly.Play();
            InAttackRange = true;
            StartCoroutine(HurtPlayer());
            DragonAnimator.SetBool("hit1", true);
        }
        
        //Monster2
        if (collision.transform.tag == "Monster2")
        {
            hitFly.Play();
            InAttackRange = true;
            StartCoroutine(HurtPlayer());
            DragonAnimator.SetBool("hit1", true);
        }
        
        //Monster3
        if (collision.transform.tag == "Monster3")
        {
            hitFly.Play();
            InAttackRange = true;
            StartCoroutine(HurtPlayer());
            DragonAnimator.SetBool("hit1", true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        DragonAnimator.ResetTrigger("hitFly");
        InAttackRange = false;
        DragonAnimator.SetBool("hit1", false);
    }
    
    //Projectile hit
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Projectile")
        {
            //Timer
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                //GameObject.FindWithTag("Player").GetComponent<ThirdPersonMovement>().speed = 10;
            }
            StartCoroutine(ExecuteAfterTime(1.2f));
            InAttackRange = true;
            StartCoroutine(HurtPlayer());
            DragonAnimator.ResetTrigger("idle");
            DragonAnimator.ResetTrigger("walk");
            DragonAnimator.SetBool("hit1", true);
            hitFly.Play();
        }
        
        if (collision.transform.tag == "Projectile" && isGrounded == false)
        {
            InAttackRange = true;
            StartCoroutine(HurtPlayer());
            DragonAnimator.SetTrigger("hitFly");
            hitFly.Play();
        }
    }
    
    //Projectile stop hitting
    void OnCollisionExit(Collision collision)
    {
        InAttackRange = false;
        Destroy(collision.gameObject);
        DragonAnimator.SetBool("hit1", false);
        DragonAnimator.ResetTrigger("walk");
        DragonAnimator.ResetTrigger("hit1");
        DragonAnimator.ResetTrigger("hitFly");
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