using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public float attackRate;
    private float nextAttackTime = 0f;
    
    void Update()
    {
        if(Time.time >= nextAttackTime && Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("attack");
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }      
}
