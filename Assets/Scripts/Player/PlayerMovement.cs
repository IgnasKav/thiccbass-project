using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    private Animator myAnimator;
    public float runSpeed;
    public float boostTimer;
    public bool boosting;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        runSpeed = 50;
        boostTimer = 0;
        boosting = false;
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        myAnimator.SetFloat("speed", Mathf.Abs(horizontalMove));
        myAnimator.SetBool("isJumping", !controller.IsGrounded());

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            myAnimator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
<<<<<<< Updated upstream
        } else if (Input.GetButtonUp("Crouch"))
=======
            controller.isSliding = false;
            myAnimator.SetBool("isSliding", controller.isSliding);
        }
        else if (Input.GetButtonUp("Crouch"))
>>>>>>> Stashed changes
        {
            crouch = false;
        }

        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 3)
            {
                runSpeed = 50;
                boostTimer = 0;
                boosting = false;
            }
        }

    }
    
    public void OnLanding()
    {
        myAnimator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        myAnimator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        bool attack = this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_attack");
        controller.StopMovement(attack);
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
