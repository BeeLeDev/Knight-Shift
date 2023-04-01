using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject hitbox;
    private GameObject existingHitbox;
    [HideInInspector]
    PlayerMovement playerMovement;
    [HideInInspector]
    SpriteRenderer sprite;
    [HideInInspector]
    Animator animator;
    // public since it's being used in PlayerMovement.cs
    [HideInInspector]
    private bool mouseButtonHeld = false;

    private void Start() {
        playerMovement = this.GetComponent<PlayerMovement>();
        animator = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // left click
        if (Input.GetMouseButtonDown(0))
        {
            // check if the hitbox collided with anything
            // if so deal damage to that object that collided with the attack
            if (!GetIsAttacking() && !mouseButtonHeld) 
            {
                mouseButtonHeld = true;
                SetIsAttacking(1);
            }
            //StartCoroutine(WaitForAnimationFinish(.5f));
            //StartCoroutine(WaitForAnimationFinish(9));
            //Debug.Log(("no attack"));
        }

        // checks to see if the Player lifted mouse indicating they are not holding the left button
        if (Input.GetMouseButtonUp(0))
        {
            mouseButtonHeld = false;
        }
    }

    // prevents attack spamming    
    IEnumerator WaitForAnimationFinish(int framesToWait)
    {
        
        //for (int i = 0; i < framesToWait; i++)
        //{
            yield return new WaitForEndOfFrame();
        //}
        
        animator.SetBool("isAttacking", false);
        //Debug.Log("can attack");
    }

    // this is used in the animation as a function event for KnightA1
    // for some reason Unity doesn't accept functions with bool parameters as function events so i am changing it to an int
    public void SetIsAttacking(int flag)
    {
        if(flag == 1)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public bool GetIsAttacking()
    {
        return animator.GetBool("isAttacking");
    }

    private void CreateHitbox()
    {
        // facing left
        if (playerMovement.GetIsFlipped())
        {
            // this rotates all, need to figure out how to rotate it once
            hitbox.transform.RotateAround(transform.position, Vector3.up, 180f);
           // hitbox.transform.RotateAround(hitbox.transform.position, Vector3.right, 180f);
            existingHitbox = Instantiate(hitbox, new Vector3(transform.position.x - (0.509f * 1.2f), transform.position.y - 0.062f, 0), hitbox.transform.rotation);
        }
        // facing right
        else
        {
            existingHitbox = Instantiate(hitbox, new Vector3(transform.position.x + (0.509f * 1.2f) , transform.position.y - 0.062f, 0), hitbox.transform.rotation);
        }
    }

    private void DeleteHitbox()
    {
        // if a hitbox exists, destroy it
        if (existingHitbox)
        {
            Destroy(existingHitbox);
        }
    }
}
