using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public HealthBar1 healthBar;

    void Start() {
        currentHealth = maxHealth;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
