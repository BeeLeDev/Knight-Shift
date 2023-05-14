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
    
    private void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (!GetIsAttacking() && GetPlayerInRange() && attackTimer > attackInterval) 
        {
            SetIsAttacking(1);
            attackTimer = 0;
        }
    }

    // this is used in the animation as a function event for KnightA1
    // for some reason Unity doesn't accept functions with bool parameters as function events so i am changing it to an int
    public void SetIsAttacking(int flag)
    {
        if(flag == 1)
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

    // used in event function
    private void CreateHitbox()
    {
        if (tag == "MeleeEnemy")
        {
            // facing left
            if (GetComponent<Enemy>().GetIsFlipped())
            {
                existingHitbox = Instantiate(attackHitbox, new Vector3(transform.position.x - (0.328f), transform.position.y - (0.216f), 0), attackHitbox.transform.rotation);

                existingHitbox.transform.RotateAround(existingHitbox.transform.position, Vector3.up, 180f);
            }
            // facing right
            else
            {
                existingHitbox = Instantiate(attackHitbox, new Vector3(transform.position.x + (0.328f) , transform.position.y - (0.216f), 0), attackHitbox.transform.rotation);
            }   
        }
        else if (tag == "RangedEnemy")
        {
            // facing left
            if (GetComponent<Enemy>().GetIsFlipped())
            {
                existingHitbox = Instantiate(attackHitbox, new Vector3(transform.position.x - (0.5f), transform.position.y, 0), attackHitbox.transform.rotation);
            }
            // facing right
            else
            {
                existingHitbox = Instantiate(attackHitbox, new Vector3(transform.position.x + (0.5f) , transform.position.y, 0), attackHitbox.transform.rotation);
            }   
        }
        else if (tag == "Boss")
        {
            // facing left
            if (GetComponent<Enemy>().GetIsFlipped())
            {
                existingHitbox = Instantiate(attackHitbox, new Vector3(transform.position.x - (0.97f), transform.position.y - (1.345f), 0), attackHitbox.transform.rotation);

                existingHitbox.transform.RotateAround(existingHitbox.transform.position, Vector3.up, 180f);
            }
            // facing right
            else
            {
                existingHitbox = Instantiate(attackHitbox, new Vector3(transform.position.x + (0.97f) , transform.position.y - (1.345f), 0), attackHitbox.transform.rotation);
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
}