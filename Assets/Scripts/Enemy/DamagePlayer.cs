using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int attackDamage;
    public Animator anim;

    void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Player") && anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy1_Attack")) {
            target.gameObject.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }
}
