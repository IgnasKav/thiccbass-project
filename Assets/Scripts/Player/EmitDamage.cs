using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitDamage : MonoBehaviour
{
    public int attackDamage;
    public Animator anim;

    void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Enemy") && anim.GetCurrentAnimatorStateInfo(0).IsName("Player_attack")) {
            target.gameObject.GetComponent<DamageReceiver>().onReceiveDamage(attackDamage);
        }
        if(target.gameObject.CompareTag("Skeleton") && anim.GetCurrentAnimatorStateInfo(0).IsName("Player_attack")) {
            target.gameObject.GetComponent<DmgReceiver>().onReceiveDamage(attackDamage);
        }
        if(target.gameObject.CompareTag("Dragon") && anim.GetCurrentAnimatorStateInfo(0).IsName("Player_attack")) {
            target.gameObject.GetComponent<DragonDamageReceiver>().onReceiveDamage(attackDamage);
        }
    }
}
