using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    private EnemyHealthManager enemyParent;

    void Awake()
    {
        enemyParent = GetComponentInParent<EnemyHealthManager>();
    }

    public void onReceiveDamage(int damage) {
        enemyParent.TakeDamage(damage);
    }
}