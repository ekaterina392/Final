using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireBreath : MonoBehaviour
{
    //Default to 3 second cooldown
    public float Cooldown = 3f;
 
    //Used as a count down timer
    public float CooldownCountdown = 0f;
    
    public GameObject TheEnd;
    public GameObject CanvasEvil;
    public ParticleSystem fireBreath;
    private Animator DragonAnimator;

    private void Awake()
    {
        TheEnd.SetActive(false);
    }

    void Start()
    {
        DragonAnimator = gameObject.GetComponent<Animator>();
    }
    
    void Update()
    {
        if (fireBreath == null)
        {
            DragonAnimator.SetBool("fire", false);
            DragonAnimator.SetTrigger("idle");

        }

        DragonAnimator.ResetTrigger("walk");
        DragonAnimator.SetTrigger("idle");

        //Fly Fire Breath
        if (CooldownCountdown < 0f)
        {
            if (Input.GetKeyDown(KeyCode.F) && CanvasEvil == null)
            {
                //reset the cooldown timer
                CooldownCountdown = Cooldown;
                
                //print a message to the console
                Debug.Log("Registered click");
                
                DragonAnimator.SetBool("fire", true);
            
                DragonAnimator.ResetTrigger("walk");
                DragonAnimator.ResetTrigger("idle");
            
                CreateParticles();
            }
        } else
        {
            //Countdown the timer with the time past in the last frame
            CooldownCountdown -= Time.deltaTime;
        }
        

        if (DragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("breath fire"))
        {
            //Stop Particles
            IEnumerator ExecuteAfterTime2(float time)
            {
                yield return new WaitForSeconds(time);
                Destroy(fireBreath);            
            }
            StartCoroutine(ExecuteAfterTime2(2));
            
            //Here scene will change
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                TheEnd.SetActive(true);
            }
            StartCoroutine(ExecuteAfterTime(9));
        }
        
        /*
        //Stops Fly Fire Breath and its sounds if incorrect animation is played
        if (DragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            StopParticles();

        } */

    }
    
    void CreateParticles()
    {
        fireBreath.Play();
    }
    
    void StopParticles()
    {
        fireBreath.Stop();
    }
}
