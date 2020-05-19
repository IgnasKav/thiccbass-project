using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDetection : MonoBehaviour
{
    private Dragon enemyParent;

    void Awake() {
        enemyParent = GetComponentInParent<Dragon>();
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemyParent.StopCooling();
            enemyParent.target = trig.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }
    }
}
