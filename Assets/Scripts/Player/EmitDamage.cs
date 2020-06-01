using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitDamage : MonoBehaviour
{
    public int attackDamage;
    public Animator anim;

    void OnTriggerEnter2D(Collider2D target) {
        bool attacking = anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack1") || anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack2") || anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack3");
        if(target.gameObject.CompareTag("Enemy") && attacking) {
            target.gameObject.GetComponent<DamageReceiver>().onReceiveDamage(attackDamage);
        }
        if(target.gameObject.CompareTag("Skeleton") && attacking) {
            target.gameObject.GetComponent<DmgReceiver>().onReceiveDamage(attackDamage);
        }
        if(target.gameObject.CompareTag("Dragon") && attacking) {
            target.gameObject.GetComponent<DragonDamageReceiver>().onReceiveDamage(attackDamage);
        }
    }
}
