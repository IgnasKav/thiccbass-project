using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;

    public HealthBar1 healthBar;

    void Start() {
        currentHealth = maxHealth;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        animator.SetTrigger("hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("isDead", true);
        Debug.Log("we died...");
    }
}
