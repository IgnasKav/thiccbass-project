using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit2 : MonoBehaviour
{
    public static bool isAttacking = false;
    public Animator anim;
    Rigidbody2D rb;

    public Transform sword;
    public float attackRange = 0.5f;
    
    public int attackDamage = 20;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    public Vector3 attackOffset;
    public LayerMask attackMask;
    Player player;
    GameObject warrior;

    // Start is called before the first frame update
    void Start()
    {

        warrior = GameObject.Find("Warrior");
        player = warrior.GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAttack();
    }
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(colInfo != null && colInfo.GetComponent<Player>().currentHealth > 0)
        {
            colInfo.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }
    void CheckAttack()
    {
        
        if(isAttacking && player.currentHealth > 0)
        {
            anim.SetBool("isAttacking", true);
        }
        if(isAttacking == false)
        {
            anim.SetBool("isAttacking", false);
        }
        if(player.currentHealth <= 0)
        {
            anim.SetBool("isAttacking", false);
        }
    }
    void OnDrawGizmosSelected()
    {
        if(sword == null)
        return;

        Gizmos.DrawWireSphere(sword.position, attackRange);
    }
}

