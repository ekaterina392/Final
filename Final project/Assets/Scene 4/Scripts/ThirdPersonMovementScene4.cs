using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ThirdPersonMovementScene4 : MonoBehaviour
{
    public GameObject CanvasEvil;

    //Default to 3 second cooldown
    public float Cooldown = 3f;
 
    //Used as a count down timer
    public float CooldownCountdown = 0f;
    
    public ParticleSystem fireBreath;

    private Animator DragonAnimator;

    public CharacterController controller;
    
    private float speed = 4;

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
        //float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(0f, 0f, vertical).normalized;

        //Walking
        if (direction.magnitude >= 0.1f)
        {
            float tragetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tragetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, tragetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
            
            DragonAnimator.ResetTrigger("fly");
            DragonAnimator.ResetTrigger("idle");

            DragonAnimator.SetTrigger("walk");
        }

        //Idle
        if (direction.magnitude < 0.1f)
        {
            DragonAnimator.ResetTrigger("walk");
            DragonAnimator.ResetTrigger("fly");
            DragonAnimator.ResetTrigger("breathFire");

            DragonAnimator.SetTrigger("idle");
        }
        
        //Fire
        if (Input.GetMouseButtonDown(0) && CanvasEvil == null)
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
            }
            
            StartCoroutine(ExecuteAfterTime(3));
        }

        //Jumping
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
    
    void CreateParticles()
    {
        fireBreath.Play();
    }

}
