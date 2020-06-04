using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Player : MonoBehaviour
{
    public PlayerSounds _playerSounds;
    public bool isDead = false;

    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;

    public HealthBar1 healthBar;

    private float damgeDellay = 0f;
    private GameObject healthBarObject;

    public LevelLoader levelLoader;


    void Start() {
        healthBarObject = healthBar.GetHealthBarObject();
        string path = Application.persistentDataPath + "/game_save.txt";
        if (!File.Exists(path))
        {
            currentHealth = maxHealth;
        }
        else
        {
            int data = SaveSystem.LoadPlayer();
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(int damage) {
        if(Time.time >= damgeDellay) {
            _playerSounds = FindObjectOfType<PlayerSounds>();
            _playerSounds.Grunt();
            StartCoroutine("ShowHealth");
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
            animator.SetTrigger("hurt");
            damgeDellay = Time.time + 1f / 2f;
        }

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeHealth(int healthAmmount) {
        if((currentHealth + healthAmmount) <= maxHealth) {
            StartCoroutine("ShowHealth");
            currentHealth += healthAmmount;
        }
        else {
            StartCoroutine("ShowHealth");
            currentHealth = maxHealth;
        }
        
        healthBar.setHealth(currentHealth);
    }

    private IEnumerator ShowHealth() {
        healthBarObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        healthBarObject.SetActive(false);
        yield break;
    }

    void Die()
    {
        _playerSounds = FindObjectOfType<PlayerSounds>();
        _playerSounds.Death();
        animator.SetBool("isDead", true);
        isDead = true;
        Respawn();
    }

    public void Respawn()
    {
        if (isDead)
        {
            LoadPlayer();
        }
    }

    //Save
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            SaveSystem.SavePlayer();
        }
    }

    //Load
    public void LoadPlayer()
    {
        int data = SaveSystem.LoadPlayer();
        currentHealth = maxHealth;
        healthBar.setHealth(currentHealth);
        levelLoader.LoadNextLevel(data);
    }
}
