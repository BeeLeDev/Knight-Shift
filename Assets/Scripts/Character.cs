using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    

    protected Rigidbody2D rb;
    protected SpriteRenderer sprite;
    // hit points
    public int health;
    // how fast the Player can move
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Hit"))
        {
            Debug.Log("hit");
            // take damage
            // need to make this work with buffer like collision's damage
            --health;
            //Debug.Log(health);

            // copy orginal sprite
            //Sprite originalSprite = sprite.sprite;
            //83 192 68
            Color originalColor = sprite.color;

            // change sprite to red hue for brief moment
            sprite.color = new Color(.7f, .2f, .2f);
            // change back to original sprite
            StartCoroutine(RevertColorChange(originalColor));
        }
    }

    IEnumerator RevertColorChange(Color color)
    {
        yield return new WaitForSeconds(0.35f);
        sprite.color = color;
    }
}
