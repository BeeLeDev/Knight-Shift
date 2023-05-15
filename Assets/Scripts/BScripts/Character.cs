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
    protected Animator animator;
    // flag to check if the character is already being hit or not
    protected bool hitFlag = false;
    protected Color originalColor;

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

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        // allows attacks to hit the Character under conditions
        if (other.CompareTag("Hit") && GetHealth() > 0 && !hitFlag)
        {

            // Enemies being hit by Player is implemented in Enemy class

            // this is extremely bad code, temporary for now
            // if Player hit by Enemy
            if (
                other.name == "EnemyMeleeAttackHitbox(Clone)" ||
                other.name == "EnemyRangedProjectile(Clone)" ||
                other.name == "BossAttackHitbox(Clone)" ||
                other.name == "BossSpinHitbox(Clone)" ||
                other.name == "BossExplosionHitbox(Clone)" ||
                other.name == "BossSpecialHitbox(Clone)"
                )
            {
                hitFlag = true;

                // this is bad code, it won't work if there are more than one type of "MeleeEnemy" or "RangedEnemy"
                // this is only temporary so it's fine for now
                if (other.name == "EnemyMeleeAttackHitbox(Clone)")
                {
                    TakeDamage(GameObject.FindGameObjectWithTag("MeleeEnemy").GetComponent<Enemy>().GetDamage());
                }
                else if (other.name == "EnemyRangedProjectile(Clone)")
                {
                    TakeDamage(GameObject.FindGameObjectWithTag("RangedEnemy").GetComponent<Enemy>().GetDamage());
                }
                else if
                (
                    other.name == "BossAttackHitbox(Clone)" ||
                    other.name == "BossSpinHitbox(Clone)" ||
                    other.name == "BossExplosionHitbox(Clone)" ||
                    other.name == "BossSpecialHitbox(Clone)"
                    )
                {
                    TakeDamage(GameObject.FindGameObjectWithTag("Boss").GetComponent<Enemy>().GetDamage());
                }

            }
        }
    }

    /*
    TODO: Make the character stagger when hit, need animation, make not available to do anything when hit
    */

    /*
    NOTE: i think the smart thing to do here, is to make a stagger animation play if health > 0
        if not then do death anim, instead of making it virtual and overriding it and pasting the same things
    */

    // if the Character survives damage, change color
    // if Character does not survive damage, death animation
    protected virtual IEnumerator OnHit()
    {
        // change color to red
        sprite.color = new Color(.9f, .2f, .2f);

        // play sound when hit
        GetComponent<AudioSource>().Play();

        if (GetHealth() > 0)
        {
            PlayStaggerAnimation();

            // this mean stagger animations take 0.4 seconds
            yield return new WaitForSeconds(0.4f);
            // change back to specified color
            sprite.color = originalColor;

            // can be hit again
            hitFlag = false;

            // maybe use ResetStaggerAnimation() and set hitFlag = false as animation events
            ResetStaggerAnimation();
        }
        else
        {
            PlayDeathAnimation();
            yield return new WaitForSeconds(3f);

            // removes the character
            KillCharacter();
        }

    }

    public virtual void TakeDamage(int damage)
    {
        //Debug.Log(GetHealth());
        SetHealth(GetHealth() - damage);
        StartCoroutine(OnHit());

    }

    protected virtual void KillCharacter()
    {
        Destroy(gameObject);
    }

    // this can be changeable to have a default death animation, but most likely all enemies will have different death animations
    protected virtual void PlayDeathAnimation()
    {
        // default when facing right, they fall backwards
        float rotateDirection = 90f;

        //Debug.Log("Character Death");
        transform.RotateAround(transform.position, Vector3.forward, rotateDirection);
    }

    protected virtual void PlayStaggerAnimation()
    {
        // default when facing right, they stagger backwards
        float rotateDirection = 10f;

        if (GetIsFlipped())
        {
            rotateDirection *= -1f;
        }

        //Debug.Log("Character Death");
        transform.RotateAround(transform.position, Vector3.forward, rotateDirection);
    }

    protected virtual void ResetStaggerAnimation()
    {
        // default when facing right, they stagger forward
        float rotateDirection = -10f;

        if (GetIsFlipped())
        {
            rotateDirection *= -1f;
        }

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
