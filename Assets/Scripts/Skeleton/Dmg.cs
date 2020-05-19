using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dmg : MonoBehaviour
{
    public int attackDamage;
    public Animator anim;

    void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Player") && anim.GetCurrentAnimatorStateInfo(0).IsName("Skeleton_Attack")) {
            target.gameObject.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }
}
