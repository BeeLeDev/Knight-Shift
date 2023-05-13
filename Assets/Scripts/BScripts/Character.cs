using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // [SerializeField] will show the variables in the inspector
    // we want those variables to be private and can access them through getter and setters
    // we also want to be able to change the variable in the inspector when needed

    // these 2 are protected to allow access through Child classes, and not show on Inspector
    protected Rigidbody2D rb;
    protected SpriteRenderer sprite;
    // how much damage the Character can take
    [SerializeField]
    private int health;
    // the damage a Character does each hit
    [SerializeField]
    private int damage;
    // how fast the Character can move
    [SerializeField]
    private float moveSpeed;
    // Character face direction: false - Right, true - Left
    private bool isFlipped = false;

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        // allows attacks to hit the Character under conditions
        if (other.CompareTag("Hit") && GetHealth() > 0)
        {
            TakeDamage(1);
        }
    }
    
    /*
    TODO: Make the character stagger when hit, need animation, make not available to do anything when hit
    */

    // if the Character survives damage, change color
    // if Character does not survive damage, death animation
    protected IEnumerator OnHit()
    {
        // change sprite to red hue for brief moment
        // change it back to original

        Color originalColor = sprite.color;
        // change color to red
        sprite.color = new Color(.9f, .2f, .2f);

        if (GetHealth() > 0)
        {
            yield return new WaitForSeconds(0.35f);
            // change back to specified color
            sprite.color = originalColor;
        }
        else
        {
            PlayDeathAnimation();
            yield return new WaitForSeconds(5f);
            // "kill" the character
            Destroy(gameObject);
        }
    }

    public virtual void TakeDamage(int damage)
    {
        SetHealth(GetHealth() - damage);
        StartCoroutine(OnHit());
    }

    // this can be changeable to have a default death animation, but most likely all enemies will have different death animations
    protected virtual void PlayDeathAnimation()
    {
        // default when facing right, they fall backwards
        float rotateDirection = 90f;
        
        //Debug.Log("Character Death");
        transform.RotateAround(transform.position, Vector3.forward, rotateDirection);
    }

     // if the Character is flipped, they are looking to the left
    public bool GetIsFlipped()
    {
        return isFlipped;
    }

    public void SetIsFlipped(bool isFlipped)
    {
        this.isFlipped = isFlipped;
    }

    public int GetHealth() 
    {
        return health;
    }

    // restrictions:
    // health can't go below 0
    public void SetHealth(int health)
    {
        if (health < 0)
        {
            this.health = 0;
        }
        else
        {
            this.health = health;
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    // restrictions: 
    // damage can't go below 0
    public void SetDamage(int damage)
    {
        if (damage < 0)
        {
            this.damage = 0;
        }
        else 
        {
            this.damage = damage;
        }
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    // restrictions: 
    // speed can't go below 0
    public void SetMoveSpeed(float speed)
    {
        if (speed < 0f)
        {
            this.moveSpeed = 0f;
        }
        else 
        {
            this.moveSpeed = speed;
        }
    }
}
