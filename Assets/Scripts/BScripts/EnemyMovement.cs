using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // player character
    private GameObject player;
    private Enemy enemy;
    private Animator animator;
    private CircleCollider2D attackRange;

    private void Start() {
        enemy = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
        attackRange = GetComponentInChildren<CircleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // find player, move to player, attack player
        if (EnemyCanMove())
        {
            FacePlayer();
            
            // move to Player if not in range, else attack
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            // if in SPECIFIC RANGE of Player, stop moving
            if (!GetComponent<EnemyAttack>().GetPlayerInRange())
            {
                animator.SetFloat("Speed", 1);
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.GetMoveSpeed() * Time.deltaTime);
            }
            else 
            {
                animator.SetFloat("Speed", 0);
            }   
        }
    }

    // if the Enemy is not attacking, they can move
    private bool EnemyCanMove()
    {
        // if there is a specific action being done, the enemy can't move
        // actions that restrict movement: attacking
        if (GetComponent<EnemyAttack>().GetIsAttacking())
        {
            return !GetComponent<EnemyAttack>().GetIsAttacking();
        }
        return true;
    }

    private void FacePlayer()
    {
        // default is facing right

        if (player.transform.position.x < transform.position.x && !enemy.GetIsFlipped())
        {
            enemy.SetIsFlipped(true);
            transform.RotateAround(transform.position, Vector3.up, 180f);
        }

        if (player.transform.position.x > transform.position.x && enemy.GetIsFlipped())
        {
            enemy.SetIsFlipped(false);
            transform.RotateAround(transform.position, Vector3.up, 180f);
        }
    }
}