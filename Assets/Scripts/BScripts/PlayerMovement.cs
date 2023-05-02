using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    private Player player;
    [HideInInspector]
    private Animator animator;
    // inputs to move horizontally
    [HideInInspector]
    public float horizontalInput;
    // inputs to move vertically
    [HideInInspector]
    public float verticalInput;
    // horizontalInput and verticalInput change every frame
    // mainly used when wanting to check input without the values changing
    // used in PlayerDodge
    private float lastHorizontalInput;
    private float lastVerticalInput;

    private void Start() {
        player = gameObject.GetComponent<Player>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // inputs to move horizontally
        horizontalInput = Input.GetAxisRaw("Horizontal");
        // inputs to move vertically
        verticalInput = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Speed", new Vector2(horizontalInput, verticalInput).sqrMagnitude);

        // Move the player
        if (PlayerCanMove())
        {
            // keeps track of which side the Player is facing (true) Left, or (false) Right
            // by default i will make the Player always face right in the beginning
            // the reason i use RotateAround() instead of flipping the sprite, is so the collider can flip along with the Player, otherwise the collider would stay the same if the sprite is flipped
            if (horizontalInput > 0 && player.GetIsFlipped())
            {
                player.SetIsFlipped(false);
                transform.RotateAround(transform.position, Vector3.up, 180f);

            }
            else if (horizontalInput < 0 && !player.GetIsFlipped())
            {
                player.SetIsFlipped(true);
                transform.RotateAround(transform.position, Vector3.up, 180f);
            }

            // movement
            if (player.GetIsFlipped())
            {
                // we normalize the movements otherwise the speed when moving diagonal would account for both inputs making it go faster
                transform.Translate(new Vector2(-horizontalInput, verticalInput).normalized * player.GetMoveSpeed() * Time.deltaTime);
                
            }
            else
            {
                transform.Translate(new Vector2(horizontalInput, verticalInput).normalized * player.GetMoveSpeed() * Time.deltaTime);
            }
        }
    }

    // if the Player is not attacking, they can move
    private bool PlayerCanMove()
    {
        // if there is a specific action being done, the player can't move
        // actions that restrict movement: attacking, dodging
        if (gameObject.GetComponent<PlayerAttack>().GetIsAttacking())
        {
            return !gameObject.GetComponent<PlayerAttack>().GetIsAttacking();
        }
        else if (gameObject.GetComponent<PlayerDodge>().GetIsDodging())
        {
            return !gameObject.GetComponent<PlayerDodge>().GetIsDodging();
        }
        return true;
    }

    // used in event functions
    // this will allow us to determine whether we dodge left or right
    public float GetHorizontalInput()
    {
        return horizontalInput;
    }

    // used in event functions
    // this will allow us to determine whether we dodge up or down
    public float GetVerticalInput()
    {
        return verticalInput;
    }

    public float GetLastHorizontalInput()
    {
        return lastHorizontalInput;
    }

    public float GetLastVerticalInput()
    {
        return lastVerticalInput;
    }

    public void SetLastHorizontalInput()
    {
        lastHorizontalInput = GetHorizontalInput();
    }

    public void SetLastVerticalInput()
    {
        lastVerticalInput = GetVerticalInput();
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