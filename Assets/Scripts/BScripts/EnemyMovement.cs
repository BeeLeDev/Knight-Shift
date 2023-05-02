using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    private Animator animator;
    private CircleCollider2D attackRange;

    public GameObject player;

    private void Start() {
        enemy = gameObject.GetComponent<Enemy>();
        animator = gameObject.GetComponent<Animator>();
        attackRange = gameObject.GetComponentInChildren<CircleCollider2D>();

        player = GameObject.Find("Player");
    }

    void Update()
    {
        // Move the player
        if (EnemyCanMove())
        {
            FacePlayer();
            
            // move to Player if not in range, else attack
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            // if in SPECIFIC RANGE of Player, stop moving
            if (!GetComponent<EnemyAttack>().GetPlayerInRange())
            {
                animator.SetFloat("Speed", 1);
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemy.GetMoveSpeed() * Time.deltaTime);
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
        // if there is a specific action being done, the player can't move
        // actions that restrict movement: attacking, dodging
        if (gameObject.GetComponent<EnemyAttack>().GetIsAttacking())
        {
            return !gameObject.GetComponent<EnemyAttack>().GetIsAttacking();
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