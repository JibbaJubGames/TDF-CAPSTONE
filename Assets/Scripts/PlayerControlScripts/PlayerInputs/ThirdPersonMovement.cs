using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{
    [Header("SetUp")]
    public CharacterController controller;
    public Transform cam;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    [Header("Movement")]
    public float speed = PlayerStatsScript.speed;
    public float gravity = -9.81f;
    public float jumpHeight = 3;

    [Header("Jump and Gravity")]
    Vector3 velocity;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Sprint Details")]
    public bool isSprinting = false;
    public float sprintSpeedMultiplier;
    private bool controllerSprintActive = false;

    [Header("Animation")]
    public Animator jerbulchaAnim;

    //timer variables
    float currentTime = 0.0f;
    float actionSpeed;
    

    

    // Update is called once per frame
    void Update()
    {
        Jump();

        Gravity();

        Walk();

        CheckSprint();

        JumpAnimCheck();

        DiveAnimTrigger();

       // BurstTimer();



    }

    private void DiveAnimTrigger()
    {
        if (Input.GetButtonUp("DodgeRoll") && BlacksmithSubtitle.atCounter == false)
        {
            jerbulchaAnim.SetTrigger("Diving");
        }
    }

    private void CheckSprint()
    {
        //Check keyboard input to trigger sprint
        if (Input.GetButtonDown("Sprint"))
        {
            Debug.Log("We're meant to be running");                      
            isSprinting = true;
            speed = speed * sprintSpeedMultiplier;
        }
        //Check controller input to trigger sprint
        else if (Input.GetAxis("SprintController") == 1 && controllerSprintActive == false && isSprinting == false)
        {
            isSprinting = true;
            speed = speed * sprintSpeedMultiplier;
            controllerSprintActive = true;
        }

        //Check keyboard input to deactivate sprint
        if (Input.GetButtonUp("Sprint") && isSprinting) 
        {
            isSprinting = false;
            speed = speed / sprintSpeedMultiplier;
        }
        //Check controller input to deactivate sprint
        else if (Input.GetAxis("SprintController") <= .25f && controllerSprintActive == true)
        {
            isSprinting = false;
            speed = speed / sprintSpeedMultiplier;
            controllerSprintActive = false;
        }
    }

    private void Walk()
    {
        if (PlayerHealth.midAttack == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                //Should be multiplied by Rad2Deg, but that doesn't exist apparently, so for now I use this...
                float targetAngle = MathF.Atan2(direction.x, direction.z) * 360 / (MathF.PI * 2) + cam.eulerAngles.y;

                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }

            WalkAndRunAnim(horizontal, vertical);
        }
    }

    private void WalkAndRunAnim(float horizontal, float vertical)
    {
        //Walk Anim Trigger
        if (horizontal == 0 && vertical == 0 || !isGrounded || PlayerHealth.midAttack)
        {
            jerbulchaAnim.SetBool("IsWalking", false);
        }
        else
        {
            jerbulchaAnim.SetBool("IsWalking", true);
        }

        //Run Anim Trigger
        if (jerbulchaAnim.GetBool("IsWalking") == true && isSprinting == true && isGrounded)
        {
            jerbulchaAnim.SetBool("IsRunning", true);
        }
        else
        {
            jerbulchaAnim.SetBool("IsRunning", false);
        }
    }

    private void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            
            jerbulchaAnim.SetTrigger("Jump");

            
        }
    }

    private void JumpAnimCheck()
    {
        
        if (isGrounded)
        {
            jerbulchaAnim.SetBool("Grounded", true);
        }
        else
        {
            jerbulchaAnim.SetBool("Grounded", false);
            
        }

        if (Input.GetButtonDown("Jump"))
        {
            jerbulchaAnim.SetTrigger("Jump");
        }
       
        
    }
    
    //public void BurstForward(float speed,float timeToStop)
    //{   //used to move character forward during actions eg attacks, rolls, ect
    //    currentTime = timeToStop;
    //    actionSpeed = speed;
    //    Debug.Log("aaaaaaaaaaaaaaaaaaaaaah");
//
   // }

   // void BurstTimer()
   // {
   //     //timer to stop action movement
   //     currentTime -= Time.deltaTime;
//
  //      if (currentTime>=0.0f) 
  //      {
   //         float horizontal = Input.GetAxis("Horizontal");
   //         float vertical = Input.GetAxis("Vertical");
   //         Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
    //        float targetAngle = MathF.Atan2(direction.x, direction.z) * 360 / (MathF.PI * 2) + cam.eulerAngles.y;
    //        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
    //        controller.Move(moveDir.normalized * speed * Time.deltaTime * actionSpeed);
   //     }
   // }

    

}

