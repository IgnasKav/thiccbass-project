using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOnPickup : MonoBehaviour
{
    public float speedBoost = 100f;

    //Paimamas consumable
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject Warrior = GameObject.Find("Warrior");
        PlayerMovement playerScript = Warrior.GetComponent<PlayerMovement>();
        playerScript.boosting = true;
        playerScript.runSpeed = speedBoost;

        Destroy(gameObject);
    }
}