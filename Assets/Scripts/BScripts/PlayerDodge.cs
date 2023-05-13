using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    // how much the Player moves when dodging
    public float translationAmount;

    private PlayerMovement playerMovement;
    private Animator animator;
    private PolygonCollider2D originalHitbox;
    private bool rightMouseButtonHeld = false;
    
    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        originalHitbox = GetComponent<PolygonCollider2D>();
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

    /*
    TODO: Eventually, create a stamina bar that allows the Player to dodge if they have enough stamina
    */
    
    // used in event function
    private void MoveDuringRoll()
    {
        // the total movement they will do at the end depending on the keys
        Vector2 dodgeMovement = new Vector2(0, 0);

        // moving left or right
        if (playerMovement.GetLastHorizontalInput() != 0)
        {
            dodgeMovement += new Vector2(translationAmount, 0);
        }
        // moving up
        if (playerMovement.GetLastVerticalInput() > 0)
        {
            dodgeMovement += new Vector2(0, translationAmount);
        }
        // moving down
        if (playerMovement.GetLastVerticalInput() < 0)
        {
            dodgeMovement += new Vector2(0, -translationAmount);
        }
        // not moving, move the direction they are facing
        if (playerMovement.GetLastHorizontalInput() == 0 && playerMovement.GetLastVerticalInput() == 0)
        {
            dodgeMovement = new Vector2(translationAmount, 0);
        }
        //Debug.Log(dodgeMovement);
        //Debug.Log(dodgeMovement.normalized);

        // normalize the dodgeMovement vector if its magnitude is greater than 1
        // i don't think this helps much
        /*
        if (dodgeMovement.magnitude > 1)
        {
            dodgeMovement.Normalize();
        }
        transform.Translate(dodgeMovement * translationAmount);
        */

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
}
