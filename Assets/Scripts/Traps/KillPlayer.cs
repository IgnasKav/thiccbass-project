using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private int attackDamage = 25;

    void OnTriggerEnter2D(Collider2D target) {
        DamgePlayer(target);
    }

    void OnTriggerStay2D(Collider2D target) {
        DamgePlayer(target);
    }

    void DamgePlayer(Collider2D target) {
        if(target.gameObject.CompareTag("Player")) {
            target.gameObject.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }
}
