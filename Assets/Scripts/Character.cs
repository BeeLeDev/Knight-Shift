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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // the object colliding has tag "Hit" and the Character hit is not red
        if (other.CompareTag("Hit") && sprite.color != new Color(.9f, .2f, .2f))
        {
            //this.TakeDamage(other.GetComponent<Character>().damage);
            this.TakeDamage(1);
        }
    }

    IEnumerator ColorChange(Color color)
    {
        // change color to red
        sprite.color = new Color(.9f, .2f, .2f);

        if (HealthAboveZero(health))
        {
            yield return new WaitForSeconds(0.35f);
            // change back to specified color
            this.sprite.color = color;
        }
        else
        {
            this.PlayDeathAnimation();

            // remove the Player's movement, they are dead, they shouldn't move
            if (gameObject.GetComponent<PlayerMovement>())
            {
                Destroy(gameObject.GetComponent<PlayerMovement>());
            }
            yield return new WaitForSeconds(5f);
            // "kill" the character
            // can add an animation here r
            Destroy(gameObject);
        }
    }

    private bool HealthAboveZero(int health)
    {
        return this.health > 0;
    }

    public void TakeDamage(int damage)
    {
        this.health -= damage;

        // change sprite to red hue for brief moment
        // change it back to original
        Color originalColor = sprite.color;
        StartCoroutine(ColorChange(originalColor));
    }

    // this can be changeable to have a default death animation, but most likely all enemies will have different death animations
    protected virtual void PlayDeathAnimation()
    {
        Debug.Log("Character Death");
        gameObject.transform.RotateAround(new Vector3(transform.position.x, transform.position.y - 0.5f, 0), Vector3.forward, -90f);
    }
}
