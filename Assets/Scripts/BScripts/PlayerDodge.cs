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
    // need these to be in global so the result is not stored temporarily
    private float lastHorizontalKey;
    private float lastVerticalKey;


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
        Vector2 dodgeMovement = new Vector2(0, 0);
        // translate the character a certain amount of position
        // GET ORIGINAL X POSITION, FIND ENDING X POSITION, difference should be 1.25f
        // there are 7 frames in the dodge, so each frame should move the Player 0.178f

        // moving left or right
        if (lastHorizontalKey != 0)
        {
            dodgeMovement += new Vector2(0.2f, 0);
        }
        // moving up
        if (lastVerticalKey > 0)
        {
            dodgeMovement += new Vector2(0, 0.2f);
        }
        // moving down
        if (lastVerticalKey < 0)
        {
            dodgeMovement += new Vector2(0, -0.2f);
        }
        // not moving, move the direction they are facing
        if (lastHorizontalKey == 0 && lastVerticalKey == 0)
        {
            dodgeMovement = new Vector2(0.2f, 0);
        }
        Debug.Log(dodgeMovement);
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

    // used in event functions
    // this will allow us to determine whether we dodge left or right
    private void DetectLastHorizontalKey()
    {
        if (this.GetComponent<PlayerMovement>().horizontalInput > 0 || this.GetComponent<PlayerMovement>().horizontalInput <= 0)
        {
            //Debug.Log("Set Vertical");
            lastHorizontalKey = this.GetComponent<PlayerMovement>().horizontalInput;
        }
        else
        {
            //Debug.Log("Set Horizontal");
            lastHorizontalKey = 0;
        }
    }

    // used in event functions
    // this will allow us to determine whether we dodge up or down
    private void DetectLastVerticalKey()
    {
        if (this.GetComponent<PlayerMovement>().verticalInput > 0 || this.GetComponent<PlayerMovement>().verticalInput <= 0)
        {
            //Debug.Log("Set Vertical");
            lastVerticalKey = this.GetComponent<PlayerMovement>().verticalInput;
        }
        else
        {
            //Debug.Log("Set Horizontal");
            lastVerticalKey = 0;
        }
    }

    
}
