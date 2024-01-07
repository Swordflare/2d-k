using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brr : MonoBehaviour
{
    public CharacterController2D controlller;
    public Animator animator;
    public float runSpeed = 0f;
    bool jump = false;
    bool crouch = false;
    public Transform size;
    void Start(){
        runSpeed = 0f;
    }
    void Update(){
        if (Input.GetButtonDown("Start")){
            runSpeed = 100f;
        }
        animator. SetFloat("Speed", runSpeed);
        if (Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("InAir", true);
        }
        if (Input. GetButtonDown("Crouch")){
            crouch = true;
        } else if (Input. GetButtonUp("Crouch")){
            crouch = false;
        }
    }
    public void OnGround(){
        animator.SetBool("InAir", false);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        controlller.Move(runSpeed * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
