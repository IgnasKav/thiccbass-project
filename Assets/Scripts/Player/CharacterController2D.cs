using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    public PlayerMovement movement;

    [SerializeField] private float m_JumpForce = 1100f;
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = 0.0f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f; 
    [SerializeField] private bool m_AirControl = false;                         
    [SerializeField] private LayerMask m_WhatIsGround;                         
    [SerializeField] private Transform m_CeilingCheck;                          
    [SerializeField] private Collider2D m_CrouchDisableCollider;                

    const float k_CeilingRadius = .2f;
    private Rigidbody2D rigidbody2D;
    private Animator myAnimator;
    private BoxCollider2D boxCollider2D;
    private bool m_FacingRight = true; 
    private Vector3 m_Velocity = Vector3.zero;
    private float SlideTime = 0.5f;
    public float slideTimeLeft = 0.0f;
    public bool isSliding = false;
    public bool stop = false;
    
    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }
    public void AttemptToSlide()
    {
        isSliding = true;
        slideTimeLeft = SlideTime;
    }

    public void CheckSlide()
    {
        if (isSliding)
        {
            if (slideTimeLeft > 0.0f)
            {
                slideTimeLeft -= Time.deltaTime;
            }
            if(slideTimeLeft <= 0.0f)
            {
                isSliding = false;
                stop = true;
            }
            stop = false;
        }
    }

    private void FixedUpdate()
    {
        bool grounded = IsGrounded();
    }

    public bool IsGrounded() {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraHeight, m_WhatIsGround);

        return raycastHit.collider != null;
    }

    public void Move(float move, bool crouch, bool jump)
    {
        if (!crouch)
        {
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }
        if (IsGrounded() || m_AirControl)
        {

            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }
            
            Vector3 targetVelocity = new Vector2(move * 10f, rigidbody2D.velocity.y);
            rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }
        }
        if (IsGrounded() && jump)
        {
            rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

    public void StopMovement(bool active)
    {
        if (active)
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
        if (!active)
            rigidbody2D.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
    }


    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}