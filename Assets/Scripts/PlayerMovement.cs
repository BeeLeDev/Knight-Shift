using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    PlayerClass playerClass;
    public float stopSpeed = 1.0f;

    private void Start() {
        playerClass = GetComponent<PlayerClass>();
        
    }

    void Update()
    {
        // inputs to move horizontally
        float horizontalInput= Input.GetAxisRaw("Horizontal");
        // inputs to move vertically
        float verticalInput= Input.GetAxisRaw("Vertical");

        // Move the player
        transform.Translate(new Vector2(horizontalInput, verticalInput) * playerClass.moveSpeed * Time.deltaTime);
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