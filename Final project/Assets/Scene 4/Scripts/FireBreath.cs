using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireBreath : MonoBehaviour
{
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
        DragonAnimator.ResetTrigger("walk");
        DragonAnimator.SetTrigger("idle");

        //Fire
        if (Input.GetKeyDown(KeyCode.F) && CanvasEvil == null)
        {
            DragonAnimator.SetBool("fire", true);
            
            DragonAnimator.ResetTrigger("walk");
            DragonAnimator.ResetTrigger("idle");
            
            CreateParticles();
        }
        
        if (DragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("breath fire"))
        {
            //Here scene will change
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                Debug.Log("bla");
                
                TheEnd.SetActive(true); //DESTROY ALL SOUNDS LIKE FIRE BREATH

            }
            
            StartCoroutine(ExecuteAfterTime(7));
        }

    }
    
    void CreateParticles()
    {
        fireBreath.Play();
    }
}
