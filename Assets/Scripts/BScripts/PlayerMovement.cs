using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public Player player;
    [HideInInspector]

    public PlayerAttack playerAttack;
    [HideInInspector]

    private Animator animator;
    private bool isFlipped = false;

    private void Start() {
        player = gameObject.GetComponent<Player>();
        playerAttack = gameObject.GetComponent<PlayerAttack>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        // inputs to move horizontally
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // inputs to move vertically
        float verticalInput = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Speed", new Vector2(horizontalInput, verticalInput).sqrMagnitude);

        // Move the player
        if (PlayerCanMove())
        {
            // keeps track of which side the Player is facing (true) Left, or (false) Right
            // by default i will make the Player always face right in the beginning
            // the reason i use RotateAround() instead of flipping the sprite, is so the collider can flip along with the Player, otherwise the collider would stay the same if the sprite is flipped
            if (horizontalInput > 0 && GetIsFlipped())
            {
                isFlipped = false;
                transform.RotateAround(transform.position, Vector3.up, 180f);

            }
            else if (horizontalInput < 0 && !GetIsFlipped())
            {
                isFlipped = true;
                transform.RotateAround(transform.position, Vector3.up, 180f);
            }

            if (GetIsFlipped())
            {
                transform.Translate(new Vector2(-horizontalInput, verticalInput) * player.moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector2(horizontalInput, verticalInput) * player.moveSpeed * Time.deltaTime);
            }
        }
    }

    // if the Player is not attacking, they can move
    private bool PlayerCanMove()
    {
        return !playerAttack.GetIsAttacking();
    }

    // if the Player is flipped, they are looking to the left
    public bool GetIsFlipped()
    {
        return isFlipped;
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