using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOnPickup : MonoBehaviour
{
    Player playerHealth;

    public int healthBonus = 30;

    void Awake()
    {
        playerHealth = FindObjectOfType<Player>();
    }
    //Paimamas consumable
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (playerHealth.currentHealth < playerHealth.maxHealth)
        {
            int health = 0;
            health = playerHealth.currentHealth + healthBonus;
            playerHealth.currentHealth = health;
            playerHealth.healthBar.setHealth(health);
            Destroy(gameObject);
        }
    }
}
