using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private Skeleton enemyParent;

    void Awake() {
        enemyParent = GetComponentInParent<Skeleton>();
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
