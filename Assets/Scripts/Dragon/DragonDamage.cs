using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDamage : MonoBehaviour
{
    public int attackDamage;
    public Animator anim;

    void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Player")) {
            target.gameObject.GetComponent<Player>().TakeDamage(attackDamage);
        }
        if(target.gameObject.CompareTag("Player")) {
            target.gameObject.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }
}
