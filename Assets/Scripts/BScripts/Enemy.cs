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
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PlayerAttackHitbox(Clone)" && other.CompareTag("Hit") && GetHealth() > 0)
        {
            TakeDamage(1);
        }
    }

    protected override void PlayDeathAnimation()
    {
        float rotateDirection = 90f;

        if (GetIsFlipped())
        {
            rotateDirection *= -1;
        }
        // when we figure out Enemy movement, we can get Enemy facing and use that
        // float rotateDirection = -90f;
        if (gameObject.tag == "BigEnemy")
        {
            Debug.Log("BigEnemy Death");

            gameObject.transform.RotateAround(new Vector3(transform.position.x, transform.position.y - 0.5f, 0), Vector3.forward, rotateDirection);
        }
        else if (gameObject.tag == "SmallEnemy")
        {
            Debug.Log("SmallEnemy Death");
            gameObject.transform.RotateAround(transform.position, Vector3.forward, rotateDirection);
        }
        
        // replace this with playing an animation if they are dead
        //transform.GetComponent<Animator>().Play("Idle", 0);
        Destroy(gameObject.GetComponent<Animator>());

        // delete all action scripts
        //Destroy(gameObject.GetComponent<EnemyMovement>());
        Destroy(gameObject.GetComponent<EnemyAttack>());
    }
}
