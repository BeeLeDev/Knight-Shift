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
        animator = GetComponent<Animator>();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        // prevented from enemy attacking itself
        // NEED TO PREVENT PLAYER FROM HITTING HITBOX
        if (other.name == "PlayerAttackHitbox(Clone)" && other.CompareTag("Hit") && GetHealth() > 0 && !hitFlag)
        {
            hitFlag = true;
            TakeDamage(1);
        }
    }

    protected override void PlayDeathAnimation()
    {
        /*
        float rotateDirection = 90f;

        if (GetIsFlipped())
        {
            rotateDirection *= -1;
        }
        // when we figure out Enemy movement, we can get Enemy facing and use that
        // float rotateDirection = -90f;
        if (gameObject.tag == "BigEnemy")
        {
            //Debug.Log("BigEnemy Death");
            transform.RotateAround(new Vector3(transform.position.x, transform.position.y - 0.5f, 0), Vector3.forward, rotateDirection);
        }
        else if (gameObject.tag == "SmallEnemy")
        {
            //Debug.Log("SmallEnemy Death");
            transform.RotateAround(transform.position, Vector3.forward, rotateDirection);
        }
        */

        animator.SetBool("isDead", true);
        
        // replace this with playing an animation if they are dead
        //transform.GetComponent<Animator>().Play("Idle", 0);
        //Destroy(GetComponent<Animator>());

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
