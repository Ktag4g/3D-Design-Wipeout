using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Varriables
    public CharacterController controller;
    public Transform cam;

    public int speed = 5;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float jumpHeight = 3f;

    //Animation Variables
    public Animator animator;

    //Gravity Variables
    private Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
            //MOVEMENT
        //Get Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //Move Player
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

            //Toggle run anim
            animator.SetBool("isRunning", true);
        }
        else
        {
            //Toggle run anim
            animator.SetBool("isRunning", false);
        }
            
            //JUMPING
        //Checks to see if player is on ground and jmps when space is pressed
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump(jumpHeight);
        }

            //GRAVITY
        //Increase velocity when falling
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        animator.SetFloat("velocity", velocity.y);

        //Checks to see if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Resets velocity when on ground
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

            //Toggle jump anim off
            animator.SetBool("isJumping", false);
        }
    }

    public void Jump(float jumpHeight)
    {
        //Toggle jump anim
        animator.SetBool("isJumping", true);
            
        //Jump
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

}
