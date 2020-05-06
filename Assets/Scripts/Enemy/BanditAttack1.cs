using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAttack1 : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Warrior"))
        {
            Bandit2.isAttacking = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Warrior"))
        {
            Bandit2.isAttacking = false;
        }
    }
}
