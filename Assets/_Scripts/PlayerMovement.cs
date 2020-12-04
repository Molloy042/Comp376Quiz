// ------------------------------------------------------------------------------ 
// Quiz  
// Written by: wenbo zhong 40023157
// For COMP 376 – Fall 2020 
// ----------------------------------------------------------------------------- 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private CharacterController controller;
    [SerializeField, Min(0)] private float speed = 5f;
    [SerializeField, Min(0)] private float rotationSpeed = 10f;

    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField, Min(0)] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField, Min(0)] private float jumpHeight = 2f;

    private Vector3 movement;
    public Vector3 gravitationalForce;
    private bool isGrounded;
    private bool jumpMomentumCheck;
    public AudioClip JumpSound;
    public AudioSource audio;
    public Animator animator;
    public Rigidbody rb;
    float timer = 0.0f;
    float cu = 0;
    public GameObject healthbartoggle;
    bool sw;

    private void Start() {
        healthbartoggle.SetActive(false);
        sw=false;

    }

    

    private void  Update()
    {
        // check if mario is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, whatIsGround);
        //animator.SetBool("Punch",false);

        // calculate movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 forward = Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(cam.transform.right, Vector3.up).normalized;
        movement = right * horizontal + forward * vertical;

        // check if player is trying to move
        if (movement != Vector3.zero)
        {
            // look in the direction of the movement
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.1f*rotationSpeed * Time.deltaTime);
            animator.SetBool("Run",true);
        }else{
            animator.SetBool("Run",false);
        }

        jumpMomentumCheck = jumpMomentumCheck && Input.GetButton("Jump") && !isGrounded;

        // simulate gravity
        if (isGrounded)
        {
            // mario is standing on ground
            gravitationalForce.y = gravity * Time.deltaTime;
            jumpMomentumCheck = true;
            animator.SetBool("Jump",false);
            if(timer != 0){
                
                if(timer>1.4){
                    healthbartoggle.SetActive(true);
                    GameObject.Find("HealthBar").GetComponent<HealthBar>().current -=15;
                }else if(timer>1.2){
                    healthbartoggle.SetActive(true);
                    GameObject.Find("HealthBar").GetComponent<HealthBar>().current -=6;                    
                }else if(timer>1){
                    healthbartoggle.SetActive(true);
                    GameObject.Find("HealthBar").GetComponent<HealthBar>().current -=2;                    
                }
                timer = 0f;
            }
            if(cu >= 0.2){
                animator.SetBool("Punch",false);
              cu = 0;
              sw=false;
            }
              
            if(Input.GetKeyDown(KeyCode.E) && cu==0){
                animator.SetBool("Punch",true); 
               Debug.Log(cu);
               sw=true;
            }
            if(sw)
                cu+= Time.deltaTime;
            
        }
        else
        {
            // mario is in the air
            if (!jumpMomentumCheck && gravitationalForce.y > 0)
                gravitationalForce.y = 0;
            else
                gravitationalForce.y += gravity * Time.deltaTime;

            timer += Time.deltaTime;
        }
      

        // jump
        if (Input.GetButton("Jump") && isGrounded){
            gravitationalForce.y = Mathf.Sqrt(-2 * jumpHeight * gravity);
            if(Time.timeScale != 0f)
                audio.PlayOneShot(JumpSound);
            animator.SetBool("Jump",true);
        }
            

        // move mario
        
        controller.Move((movement * speed * Time.deltaTime) + (gravitationalForce * Time.deltaTime));
    }
    void  OnCollisionEnter(Collision collision){
       
             if ( collision.gameObject.name.Contains("crate"))
            {
                if(Input.GetKey(KeyCode.E)){
                    Debug.Log("punch");
                    Destroy(collision.gameObject);
                }
            }
    }
}
    
