using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public GameObject hitbox;
    private GameObject existingHitbox;
    [HideInInspector]
    Animator animator;
    // controllable time
    private float time;
    // time before next attack in seconds
    public float attackInterval;
    // assuming the monster is not spawned in front of the Enemy
    // NOTE: i wonder if spawning inside the object counts as a collision, need to test, if so we can keep this false
    private bool playerInRange = false;

    /*
    TODO: don't allow the enemy to get hit their own range checker
    */
    
    private void Start() {
        animator = gameObject.GetComponent<Animator>();
        time = 0f;
        attackInterval = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!GetIsAttacking() && GetPlayerInRange() && time > attackInterval) 
        {
            SetIsAttacking(1);
            time = 0;
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
        // facing left
        if (gameObject.GetComponent<Enemy>().GetIsFlipped())
        {
            // hitbox.transform.RotateAround(hitbox.transform.position, Vector3.right, 180f);
            existingHitbox = Instantiate(hitbox, new Vector3(transform.position.x - (0.578f), transform.position.y + (0.043f), 0), hitbox.transform.rotation);

            existingHitbox.transform.RotateAround(existingHitbox.transform.position, Vector3.up, 180f);
        }
        // facing right
        else
        {
            existingHitbox = Instantiate(hitbox, new Vector3(transform.position.x + (0.578f) , transform.position.y + (0.043f), 0), hitbox.transform.rotation);
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
