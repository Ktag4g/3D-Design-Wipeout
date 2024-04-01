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

    //Animation Variables
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        //Get Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        controller.Move(new Vector3(0, -1, 0));

        //Move Player/Toggle Walking Anim
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
    }

}
