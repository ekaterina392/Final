using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class FireBreath : MonoBehaviour
{
    public GameObject RestartTrigger;
    public AudioSource BackgroundMusic;
    public AudioSource MonsterFire;
    public AudioSource MonsterScream;
    public AudioSource FireBreath2;
    public AudioSource WomanCry;
    
    //Default to 3 second cooldown
    public float Cooldown = 3f;
 
    //Used as a count down timer
    public float CooldownCountdown = 0f;
    
    public GameObject TheEnd;
    public GameObject Button;
    public GameObject CanvasEvil;
    public ParticleSystem fireBreath;
    private Animator DragonAnimator;

    private void Awake()
    {
        Button.SetActive(false);
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

                FireBreath2.PlayDelayed(0.3f);
                MonsterFire.PlayDelayed(2);
                MonsterScream.PlayDelayed(3.5f);
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
            
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                TheEnd.SetActive(true);
                BackgroundMusic.Stop();
                MonsterFire.Stop();
                MonsterScream.Stop();
                FireBreath2.Stop();
                WomanCry.Stop();
            }
            StartCoroutine(ExecuteAfterTime(9));
            
            //Here scene will change
            IEnumerator ExecuteAfterTime3(float time)
            {
                yield return new WaitForSeconds(time);
                Button.SetActive(true);
                Destroy(RestartTrigger);
            }
            StartCoroutine(ExecuteAfterTime3(18));
        }

        if (RestartTrigger == null && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Scene 0");
        }
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