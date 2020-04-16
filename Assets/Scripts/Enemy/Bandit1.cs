using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit1 : MonoBehaviour
{
    public static bool isAttacking = false;
    Animator anim;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking)
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }
    
    /*
    void FixedUpdate()
    {
        if(!isAttacking)
        {
            rb.velocity = new Vector2(dirX * moveSpeed)
        }
    }
    */
}
