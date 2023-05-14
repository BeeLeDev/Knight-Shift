using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        originalColor = sprite.color;
        animator = GetComponent<Animator>();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        // prevented from enemy attacking itself
        if (other.name == "PlayerAttackHitbox(Clone)" && other.CompareTag("Hit") && GetHealth() > 0 && !hitFlag)
        {
            hitFlag = true;

            // take damage based on Player's damage
            TakeDamage(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetDamage());
        }
    }

    protected override void PlayDeathAnimation()
    {
        animator.SetBool("isDead", true);
        
        // delete all action scripts
        Destroy(GetComponent<EnemyMovement>());
        Destroy(GetComponent<EnemyAttack>());
        Destroy(GetComponent<PolygonCollider2D>());
    }

    protected override void PlayStaggerAnimation()
    {
        SetIsStaggering(1);
        GetComponent<EnemyAttack>().SetIsAttacking(0);
    }

    protected override void ResetStaggerAnimation()
    {
        SetIsStaggering(0);
    }

    public void SetIsStaggering(int flag)
    {
        if(flag == 1)
        {
            animator.SetBool("isStaggering", true);
        }
        else
        {
            animator.SetBool("isStaggering", false);
        }
    }

    public bool GetIsStaggering()
    {
        return animator.GetBool("isStaggering");
    }
}
