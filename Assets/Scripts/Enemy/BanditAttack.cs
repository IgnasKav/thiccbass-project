using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAttack : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Warrior"))
        {
            Bandit1.isAttacking = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Warrior"))
        {
            Bandit1.isAttacking = false;
        }
    }
}
