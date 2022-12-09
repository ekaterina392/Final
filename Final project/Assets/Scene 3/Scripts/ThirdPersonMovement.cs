using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ThirdPersonMovement : MonoBehaviour
{
    //Default to 3 second cooldown
    public float Cooldown = 3f;
 
    //Used as a count down timer
    public float CooldownCountdown = 0f;
    
    public ParticleSystem fireBreath;

    private Animator DragonAnimator;

    public CharacterController controller;

    public Transform camera;

    public float speed = 10;
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
    
    /*
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "cube")
        {
            Debug.Log("collision");
        }
    } */
    
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
        
        /*
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        } */
        
        if (Input.GetKeyDown(jumpKey))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (isGrounded == false)
        {
            DragonAnimator.ResetTrigger("idle");
            DragonAnimator.ResetTrigger("breathFire");

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
            }
        } else
        {
            //Countdown the timer with the time past in the last frame
            CooldownCountdown -= Time.deltaTime;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        
        //Stops Fly Fire Breath if incorrect animation is played
        if (DragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            StopParticles();
        }
        
        if (DragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            StopParticles();
        }
        
        if (DragonAnimator.GetCurrentAnimatorStateInfo(0).IsName("fly hit"))
        {
            StopParticles();
        }

        /*
        if (fireBreath.isPlaying)
        {
            DragonAnimator.ResetTrigger("fly");
            DragonAnimator.SetTrigger("breathFire");
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
