using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump1 : MonoBehaviour
{
    Rigidbody2D myRigidbody;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;


    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded;

    private bool jump;

    [SerializeField]
    private float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        HandleInput();
    }
    void FixedUpdate()
    {
        isGrounded = IsGrounded();
        
        HandleMovement();

        ResetValues();
    }
    private void HandleMovement()
    {
        if(isGrounded && jump)
        {
            isGrounded = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }
    private void ResetValues(){
        jump = false;
    }

    private bool IsGrounded(){
        if(myRigidbody.velocity.y <= 0){
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if(colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
