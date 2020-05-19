using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgReceiver : MonoBehaviour
{
    private SkeletonHealth enemyParent;
    
    void Awake()
    {
        enemyParent = GetComponentInParent<SkeletonHealth>();
    }

    public void onReceiveDamage(int damage) {
        enemyParent.TakeDamage(damage);
    }
}