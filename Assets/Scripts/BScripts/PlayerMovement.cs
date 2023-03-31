using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public Player player;
    [HideInInspector]

    public PlayerAttack playerAttack;
    [HideInInspector]
    public SpriteRenderer sprite;
    [HideInInspector]

    private Animator animator;

    private void Start() {
        player = gameObject.GetComponent<Player>();
        playerAttack = gameObject.GetComponent<PlayerAttack>();
        sprite = GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        // inputs to move horizontally
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // inputs to move vertically
        float verticalInput = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
        animator.SetFloat("Speed", new Vector2(horizontalInput, verticalInput).sqrMagnitude);


        // Move the player
        if (playerCanMove())
        {
            // keeps track of which side the Player is facing (true) Left, or (false) Right
            // by default i will make the Player always face right in the beginning
            if (horizontalInput > 0)
            {
                //Debug.Log(horizontalInput);
                //sprite.flipX = false;
                animator.ResetTrigger("isLeft");
                animator.SetTrigger("isRight");
                
            }
            else if (horizontalInput < 0)
            {
                //sprite.flipX = true;
                animator.ResetTrigger("isRight");
                animator.SetTrigger("isLeft");
                
            }

            transform.Translate(new Vector2(horizontalInput, verticalInput) * player.moveSpeed * Time.deltaTime);
        }
    }

    // if the Player is not attacking, they can move
    private bool playerCanMove()
    {
        return !playerAttack.isAttacking;
    }

}



// i was experimenting using forces for movement as it solved the Player gameObject shaking when colliding with objects due to Unity's built-in collision detection
// the proble was i couldn't figure out how to slow the force down to make the Player stop moving, if i can figure that out i might be able to use forces

/*
Class {
    // Reference to the player's rigidbody component
    private Rigidbody2D rb;
}
Start()
{
    // Get the player's rigidbody component
    rb = GetComponent<Rigidbody2D>();
}
            
Update()
{
    Debug.Log(horizontalInput);
    Debug.Log(verticalInput);
    Debug.Log(rb.totalForce);

    // Move the player using physics forces
    Vector2 movement = new Vector2(horizontalInput, verticalInput);
    rb.AddForce(movement * playerClass.moveSpeed, ForceMode2D.Force);

    if (rb.totalForce != new Vector2(0, 0) && horizontalInput == 0 & verticalInput == 0)
    {
        //rb.AddForce(-(movement * playerClass.moveSpeed), ForceMode2D.Force);
    }
}
*/