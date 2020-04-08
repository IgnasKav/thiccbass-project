using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    private Animator myAnimator;
    public float runSpeed = 50f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        myAnimator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            myAnimator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
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
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        myAnimator.SetBool("isJumping", !controller.IsGrounded());
        jump = false;
    }
}
