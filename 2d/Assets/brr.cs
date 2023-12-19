using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brr : MonoBehaviour
{
    public CharacterController2D controlller;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    public Transform size;
    void Update(){
        if (Input.GetButtonDown("Jump")){
            jump = true;
        }
        if (Input. GetButtonDown("Crouch")){
            crouch = true;
        } else if (Input. GetButtonUp("Crouch")){
            crouch = false;
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        controlller.Move(runSpeed * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
