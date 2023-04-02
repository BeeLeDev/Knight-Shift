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
    // need this to be in global so the result is not stored temporarily
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
        // translate the character a certain amount of position
        // GET ORIGINAL X POSITION, FIND ENDING X POSITION, difference should be 1.25f
        // there are 7 frames in the dodge, so each frame should move the Player 0.178f


        // move up
        if (lastVerticalKey > 0)
        {
            transform.Translate(new Vector2(0,0.2f));
        }
        // move down
        else if (lastVerticalKey < 0)
        {
            transform.Translate(new Vector2(0,-0.2f));
        }
        // move left or right
        else
        {
            transform.Translate(new Vector2(0.2f,0));
        }
        
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

    // this will allow us to determine whether we dodge up, down, left, or right
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
