using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector]
    public Enemy enemy;
    [HideInInspector]

    private Animator animator;
    private CircleCollider2D attackRange;

    private void Start() {
        enemy = gameObject.GetComponent<Enemy>();
        animator = gameObject.GetComponent<Animator>();
        attackRange = gameObject.GetComponentInChildren<CircleCollider2D>();
    }

    void Update()
    {
        // Move the player
        if (EnemyCanMove())
        {
            
            // move to Player if not in range, else attack
            // if in SPECIFIC RANGE of Player, stop moving
            // attack
            // pause for a second
            // repeat
            
        }
    }

    // if the Enemy is not attacking, they can move
    private bool EnemyCanMove()
    {
        // if there is a specific action being done, the player can't move
        // actions that restrict movement: attacking, dodging
//        if (gameObject.GetComponent<EnemyAttack>().GetIsAttacking())
        {
//            return !gameObject.GetComponent<EnemyAttack>().GetIsAttacking();
        }
        return true;
    }
}