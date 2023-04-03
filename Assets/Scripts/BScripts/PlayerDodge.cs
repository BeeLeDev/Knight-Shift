using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    [HideInInspector]
    PlayerMovement playerMovement;
    [HideInInspector]
    Animator animator;
    [HideInInspector]
    private bool rightMouseButtonHeld = false;
    private PolygonCollider2D originalHitbox;
    // assigned as the key before the roll
    // we use this instead of GetHorizontalInput() and GetVerticalInput() as we don't want the value to change mid-animation using those methods
    private float lastHorizontalInput;
    private float lastVerticalInput;
    


    private void Start() {
        playerMovement = this.GetComponent<PlayerMovement>();
        animator = this.GetComponent<Animator>();
        originalHitbox = this.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // left click
        if (Input.GetMouseButtonDown(1))
        {
            // check if the hitbox collided with anything
            // if so deal damage to that object that collided with the attack
            if (!GetIsDodging() && !rightMouseButtonHeld) 
            {
                rightMouseButtonHeld = true;
                SetIsDodging(1);
            }
            //StartCoroutine(WaitForAnimationFinish(.5f));
            //StartCoroutine(WaitForAnimationFinish(9));
            //Debug.Log(("no attack"));
        }

        // checks to see if the Player lifted mouse indicating they are not holding the left button
        if (Input.GetMouseButtonUp(1))
        {
            rightMouseButtonHeld = false;
        }

        
    }

    // TODO: Diagonal roll needs to be worked on
    // used in event function
    private void MoveDuringRoll()
    {
        // the total movement they will do at the end depending on the keys
        Vector2 dodgeMovement = new Vector2(0, 0);

        // moving left or right
        if (lastHorizontalInput != 0)
        {
            dodgeMovement += new Vector2(0.2f, 0);
        }
        // moving up
        if (lastVerticalInput > 0)
        {
            dodgeMovement += new Vector2(0, 0.2f);
        }
        // moving down
        if (lastVerticalInput < 0)
        {
            dodgeMovement += new Vector2(0, -0.2f);
        }
        // not moving, move the direction they are facing
        if (lastHorizontalInput == 0 && lastVerticalInput == 0)
        {
            dodgeMovement = new Vector2(0.2f, 0);
        }
        //Debug.Log(dodgeMovement);
        transform.Translate(dodgeMovement);
    }

    public void SetIsDodging(int flag)
    {
        if(flag == 1)
        {
            animator.SetBool("isDodging", true);
        }
        else
        {
            animator.SetBool("isDodging", false);
        }
    }

    public bool GetIsDodging()
    {
        return animator.GetBool("isDodging");
    }

    private void SetLastInputs()
    {
        lastHorizontalInput = playerMovement.GetHorizontalInput();
        lastVerticalInput = playerMovement.GetVerticalInput();
    }
}
