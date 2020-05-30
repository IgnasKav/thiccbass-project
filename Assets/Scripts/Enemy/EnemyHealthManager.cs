using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Security.Cryptography;

public class EnemyHealthManager : MonoBehaviour
{
    public GameObject[] consumableDrop;
    int random;
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy1_Hurt") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy1_Die")) {
            if(currentHealth <= 0)
            {
                animator.SetBool("isDead", true);
            }
            currentHealth -= damage;
            animator.SetTrigger("hurt");
        }
    }

    void onDeath()
    {
        random = Random.Range(0, consumableDrop.Length);
        Instantiate(consumableDrop[random], new Vector3(transform.position.x, transform.position.y - 3f, 0), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
