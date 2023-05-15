using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // time before next attack in seconds
    public float attackInterval = 2f;
    public GameObject attackHitbox;

    private GameObject existingHitbox;
    private Animator animator;
    // timer to check when enemy can attack again
    private float attackTimer = 0f;
    // assuming the monster is not spawned in front of the Enemy
    // NOTE: i wonder if spawning inside the object counts as a collision, need to test, if so we can keep this false
    private bool playerInRange = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (!GetIsAttacking() && GetPlayerInRange() && attackTimer > attackInterval)
        {
            // this is bad code, temporary
            if (tag == "Boss")
            {
                int randomAttack = Random.Range(1, 5);
                animator.SetInteger("randomAttack", randomAttack);
            }

            SetIsAttacking(1);

            // need to call DoneAttacking() at the end of every animation attack
            // its to set isAttacking to false, and reset attack timer
        }
    }

    // this is used in the animation as a function event for KnightA1
    // for some reason Unity doesn't accept functions with bool parameters as function events so i am changing it to an int
    public void SetIsAttacking(int flag)
    {
        if (flag == 1)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public bool GetIsAttacking()
    {
        return animator.GetBool("isAttacking");
    }

    // this avoids unity not being able to catch up with itself when a variable changes, spent 2-3 hours trying to figure out why unity was being dumb
    public void DoneAttacking()
    {
        SetIsAttacking(0);
        SetAttackTimer(0);
    }

    // used in event function
    private void CreateHitbox()
    {
        if (tag == "MeleeEnemy")
        {
            // facing right
            existingHitbox = Instantiate(attackHitbox, new Vector3(transform.position.x + (0.679f), transform.position.y + (-0.451f), 0), attackHitbox.transform.rotation);

            // facing left
            if (GetComponent<Enemy>().GetIsFlipped())
            {
                existingHitbox.transform.RotateAround(transform.position, Vector3.up, 180f);
            }
        }
        else if (tag == "RangedEnemy")
        {
            // facing right
            existingHitbox = Instantiate(attackHitbox, new Vector3(transform.position.x + (0.5f), transform.position.y, 0), attackHitbox.transform.rotation);

            // facing left
            if (GetComponent<Enemy>().GetIsFlipped())
            {
                existingHitbox.transform.RotateAround(transform.position, Vector3.up, 180f);
            }
        }
        else if (tag == "Boss")
        {
            // facing right
            existingHitbox = Instantiate(attackHitbox, new Vector3(transform.position.x + (1.092f), transform.position.y + (-1.417f), 0), attackHitbox.transform.rotation);

            // facing left
            if (GetComponent<Enemy>().GetIsFlipped())
            {
                existingHitbox.transform.RotateAround(transform.position, Vector3.up, 180f);
            }
        }
    }

    // used in event function
    private void DeleteHitbox()
    {
        // if a hitbox exists, destroy it
        if (existingHitbox)
        {
            Destroy(existingHitbox);
        }
    }

    public bool GetPlayerInRange()
    {
        return playerInRange;
    }

    public void SetPlayerInRange(bool playerInRange)
    {
        this.playerInRange = playerInRange;
    }

    public void SetAttackTimer(float time)
    {
        this.attackTimer = time;
    }
}