using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class brr : MonoBehaviour
{
    public CharacterController2D controlller;
    public Animator animator;
    public float runSpeed = 0f;
    bool jump = false;
    bool crouch = false;
    public Transform size;
    public Canvas gameOverText;
    public Canvas winText;
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
        
        if (Input.GetButtonDown("Stop")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Time.timeScale = 1;
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
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Water"){
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        if(collision.tag == "Lasagna"){
            winText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
