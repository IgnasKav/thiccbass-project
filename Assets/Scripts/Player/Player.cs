using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour
{
    public PlayerPosition playerPosition;
    public PlayerSounds _playerSounds;
    public bool isDead = false;

    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;

    public HealthBar1 healthBar;

    private float damgeDellay = 0f;
    private GameObject healthBarObject;


    void Start() {
        healthBarObject = healthBar.GetHealthBarObject();
        string path = Application.persistentDataPath + "/game_save.txt";
        if (!File.Exists(path))
        {
            currentHealth = maxHealth;
        }
        else
        {
            PlayerData data = SaveSystem.LoadPlayer();
            currentHealth = data.health;
            healthBar.setHealth(data.health);
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
            playerPosition.Reload();
            currentHealth = maxHealth;
            healthBar.setHealth(currentHealth);
        }
    }

    //Save
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            SaveSystem.SavePlayer(this);
        }
    }

    //Load
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Debug.Log(data.position[0]);

        Vector2 position;
        position.x = data.position[0] - 2;
        position.y = data.position[1];
        transform.position = position;

        currentHealth = data.health;
        healthBar.setHealth(data.health);
    }
}
