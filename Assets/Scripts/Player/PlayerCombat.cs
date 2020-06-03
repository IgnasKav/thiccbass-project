using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public AudioClip attackAudio;

    public float attackRate;
    private float nextAttackTime = 0f;
    private float prevAttackTime;
    private int currentAttackIndex = 0;
    private CharacterController2D player;
    private AudioSource audioScource;

    void Awake() {
        audioScource = GetComponent<AudioSource>();
        player = GetComponent<CharacterController2D>();
    }
    
    void Update()
    { 
        float currentTime = Time.time;
        if(currentTime >= nextAttackTime && Input.GetKeyDown(KeyCode.Mouse0))//prevent attack spamming
        {
            if(player.IsGrounded()) {
                if(currentTime - prevAttackTime > 1f) { // if time between attacks is too high perform 1st attack animation
                    currentAttackIndex = 0;
                }

                if(currentAttackIndex == 3) { // if it's last combo attack add a delay and reset to first attack
                    currentAttackIndex = 0;
                    nextAttackTime = currentTime + 1f / attackRate;
                }
                else { // start/continue with combo
                    audioScource.PlayOneShot(attackAudio);
                    currentAttackIndex++;
                    animator.Play("PlayerAttack" + currentAttackIndex);
                    prevAttackTime = currentTime;
                    nextAttackTime = currentTime + 0.3f;
                }
            }
            else {
                audioScource.PlayOneShot(attackAudio);
                nextAttackTime = currentTime + 0.5f / attackRate;
                animator.SetTrigger("attack");
            }
        }
    }      
}
