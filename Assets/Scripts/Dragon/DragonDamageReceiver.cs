using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDamageReceiver : MonoBehaviour
{
    private DragonHealth enemyParent;
    
    void Awake()
    {
        enemyParent = GetComponentInParent<DragonHealth>();
    }

    public void onReceiveDamage(int damage) {
        enemyParent.TakeDamage(damage);
    }
}