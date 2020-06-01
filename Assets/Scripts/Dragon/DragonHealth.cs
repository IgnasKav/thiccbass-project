using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Security.Cryptography;

public class DragonHealth : MonoBehaviour
{
    public GameObject[] consumableDrop;
    int random;
    public Animator animator;
    public int maxHealth = 200;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("SmallDragonHurt") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Dragon_Hurt"))
        {
            currentHealth -= damage;
            //animator.SetTrigger("hurt");
            if(currentHealth <= 0)
            {
                animator.SetBool("isDead", true);
            }
            if(currentHealth <= 100)
            {
                animator.SetTrigger("StageTwo");
            }
            if(currentHealth > 100)
            {
                animator.SetTrigger("hurt");
            }
            if(currentHealth <= 79)
            {
                animator.SetTrigger("hurt1");
            }
        }
    }
    void onDeath()
    {
        random = Random.Range(0, consumableDrop.Length);
        Instantiate(consumableDrop[random], new Vector3(transform.position.x, transform.position.y - 3f, 0), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
