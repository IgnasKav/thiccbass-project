using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFollow : MonoBehaviour
{
    private Dragon enemyParent;
    private bool inRange;
    private Animator anim;

    void Awake()
    {
        enemyParent = GetComponentInParent<Dragon>();
        anim = GetComponentInParent<Animator>();
    }

    void Update() {
        if (inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Dragon_Attack")) {
            enemyParent.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Player"))
        {
            enemyParent.moveSpeed *= 2;
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D trig) {
        if (trig.gameObject.CompareTag("Player"))
        {
            enemyParent.moveSpeed /= 2;
            enemyParent.TriggerCooling();
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
        }
    }
}
