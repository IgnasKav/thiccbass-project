using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public GameObject healthIndicator;
    private Animator myAnimator;
    public float runSpeed = 50f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public float boostTimer = 0;
    public bool boosting = false;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
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
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        if (boosting)
        {
            healthIndicator.SetActive(true);
            boostTimer += Time.deltaTime;
            if (boostTimer >= 3)
            {
                runSpeed = 50;
                boostTimer = 0;
                boosting = false;
                healthIndicator.SetActive(false);
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
        bool attack = myAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack1") || myAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack2") || myAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack3");
        controller.StopMovement(attack);
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
