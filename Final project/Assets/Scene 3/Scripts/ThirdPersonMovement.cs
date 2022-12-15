using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ThirdPersonMovement : MonoBehaviour
{
    public AudioSource DragonFly;
    public AudioSource FireBreathSound;
    public AudioSource DragonFootsteps;

    //Default to 3 second cooldown
    public float Cooldown = 3f;
 
    //Used as a count down timer
    public float CooldownCountdown = 0f;
    
    public ParticleSystem fireBreath;
    private Animator DragonAnimator;
    public CharacterController controller;
    public Transform camera;
    public float speed = 20;
    private float Flyspeed = 20;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    
    //Jumping
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private Vector3 velocity;
    private bool isGrounded;
    private KeyCode jumpKey = KeyCode.RightShift;
    private KeyCode jumpKey2 = KeyCode.Space;

    void Start()
    {
        DragonAnimator = gameObject.GetComponent<Animator>();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //Walking
        if (direction.magnitude >= 0.1f)
        {
            float tragetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tragetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, tragetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
            
            DragonAnimator.ResetTrigger("fly");
            DragonAnimator.ResetTrigger("idle");
            DragonAnimator.SetTrigger("walk");
        }
        
        //Flying
        if (direction.magnitude >= 0.1f && isGrounded == false)
        {
            float tragetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tragetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            
            Vector3 moveDirection = Quaternion.Euler(0f, tragetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * Flyspeed * Time.deltaTime);      
            
            DragonAnimator.ResetTrigger("walk");
            DragonAnimator.SetTrigger("fly");
        }
        
        //Idle
        if (direction.magnitude < 0.1f)
        {
            DragonAnimator.ResetTrigger("walk");
            DragonAnimator.ResetTrigger("fly");
            DragonAnimator.ResetTrigger("breathFire");
            DragonAnimator.SetTrigger("idle");
        }
        
        //Jumping
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKeyDown(jumpKey) || Input.GetKeyDown(jumpKey2))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (isGrounded == false)
        {
            DragonAnimator.ResetTrigger("idle");
            DragonAnimator.ResetTrigger("breathFire");
            DragonFootsteps.Stop();
            DragonAnimator.SetTrigger("fly");
        }
        
        //Fly Fire Breath
        if (CooldownCountdown < 0f)
        {
            if (isGrounded == false && Input.GetMouseButtonDown(0))
            {
                //reset the cooldown timer
                CooldownCountdown = Cooldown;
                //print a message to the console
                Debug.Log("Registered click");
                
                DragonAnimator.ResetTrigger("fly");
                DragonAnimator.SetTrigger("breathFire");
                CreateParticles();
                FireBreathSound.Play();
                DragonFly.Stop();
            }
        } else
        {
            //Countdown the timer with the time past in the last frame
            CooldownCountdown -= Time.deltaTime;
            DragonFly.PlayDelayed(0.53f);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (isGrounded)
        {
            DragonFly.Play();
        }
        
        //Stops Fly Fire Breath and its sounds if incorrect animation is played
        if (DragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            StopParticles();
            FireBreathSound.Stop();
            DragonFootsteps.Play(); //Idk why but it doesnt work properly with "walk"
        }
        
        if (DragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            StopParticles();
            FireBreathSound.Stop();
        }
        
        if (DragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("fly hit"))
        {
            StopParticles();
            FireBreathSound.Stop();
            DragonFootsteps.Stop();
            DragonFly.PlayDelayed(1.23f);
        }
        
        if (DragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("fly"))
        {
            DragonFootsteps.Play(); //Otherwise wont play right after landing
        }

        if (DragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("hit"))
        {
            DragonFly.Stop();
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