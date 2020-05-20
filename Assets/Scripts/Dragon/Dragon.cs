using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    #region Public Variables
    public float attackDistance;
    public float moveSpeed;
    public float attackCooldown;
    public float escapeCooldown;
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    public ParticleSystem dust;
    #endregion

    #region Private Variables

    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool cooling;
    private float timer;
    private float defaultCoolDown;
    private Transform prevPosition;
    private float chaseSpeed;
    private float currentSpeed;
    #endregion

    void Awake()
    {
        SelectTarget();
        chaseSpeed = moveSpeed * 2;
        currentSpeed = 0;
        defaultCoolDown = attackCooldown;
        timer = attackCooldown;
        anim = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Dragon_Hurt") || anim.GetCurrentAnimatorStateInfo(0).IsName("Dragon_Die")) {
            return;
        }
        if (inRange)
        {
            EnemyLogic();
        }
        if (cooling)
        {
            Cooldown();
        }
        else {
            if (!attackMode)
            {
                Move();
            }

            if (!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Dragon_Attack"))
            {
                SelectTarget();
            }
        }
    }

    void Update()
    {
        if(currentSpeed >= chaseSpeed && !attackMode) {
            if(!dust.isPlaying) {
                dust.Play();
            }  
        }
        else if(dust.isPlaying) {
            dust.Stop();
        }
    }

    void EnemyLogic() {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance) {
            StopAttack();
        }
        else if (attackDistance >= distance && !cooling) {
            Attack();
        }
    }

    void Move() {
        anim.SetBool("CanWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Dragon_Attack")) {
            Vector2 targetPosistion = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosistion, moveSpeed * Time.deltaTime);
            currentSpeed = moveSpeed;
        } else {
            currentSpeed = 0;
        }
    }

    void Attack() {
        currentSpeed = 0;
        dust.Stop();
        attackMode = true;
        anim.SetBool("CanWalk", false);
        anim.SetBool("Attack", true);
    }

    void StopAttack() {
        StopCooling();
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    private void Cooldown() {
        currentSpeed = 0;
        dust.Stop();
        timer -= Time.deltaTime;
        anim.SetBool("Attack", false);
        anim.SetBool("CanWalk", false);
        if (timer <= 0 && cooling) {
            StopCooling();
        } 
    }

    public void TriggerCooling(int coolAttack = 0) {
        timer = coolAttack == 1 ? attackCooldown : escapeCooldown;
        cooling = true;
    }

    public void StopCooling()
    {
        cooling = false;
        timer = attackCooldown;
        if (!inRange)
        {
            SelectTarget();
        }
    }

    private bool InsideofLimits() {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget() {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        Transform closerPosition = distanceToLeft < distanceToRight ? leftLimit : rightLimit;
        Transform furtherPosition = distanceToLeft > distanceToRight ? leftLimit : rightLimit;

        if (target != closerPosition && target != furtherPosition && target != null)
        {
            target = prevPosition;
        }
        else {
            target = target == closerPosition ? furtherPosition : closerPosition;
        }
        
        prevPosition = target;

        Flip();
    }

    public void Flip() {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x < target.position.x)
        {
            rotation.y = 0;
        }
        else {
            rotation.y = 180;
        }

        transform.eulerAngles = rotation;
    }
}
