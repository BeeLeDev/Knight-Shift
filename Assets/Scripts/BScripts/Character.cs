using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // these 2 are protected to allow access through Child classes, and not show on Inspector
    protected Rigidbody2D rb;
    protected SpriteRenderer sprite;
    // how much damage the Character can take
    public int health;
    // the damage a Character does each hit
    public int damage;
    // how fast the Character can move
    public float moveSpeed;
    // Character face direction: false - Right, true - Left
    [HideInInspector]
    public bool isFlipped = false;

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        // allows attacks to hit the Character under conditions
        if (other.CompareTag("Hit") && GetHealth() > 0)
        {
            //TakeDamage(other.GetComponent<Character>().damage);
            TakeDamage(1);
        }
    }

    // if the player survives damage, change color
    // if player does not survive damage, death animation
    IEnumerator OnHit()
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

    public void TakeDamage(int damage)
    {
        SetHealth(GetHealth() - damage);
        StartCoroutine(OnHit());
    }

    // this can be changeable to have a default death animation, but most likely all enemies will have different death animations
    protected virtual void PlayDeathAnimation()
    {
        // default when facing right, they fall backwards
        float rotateDirection = 90f;
        
        Debug.Log("Character Death");
        gameObject.transform.RotateAround(transform.position, Vector3.forward, rotateDirection);
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
