using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject weapon;
    [HideInInspector]
    PlayerMovement playerMovement;
    [HideInInspector]
    public bool isAttacking = false;
    private bool mouseButtonHeld = false;

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // left click
        if (Input.GetMouseButtonDown(0))
        {
            // this function will play an attack animation
            // check if the hitbox collided with anything
            // if so deal damage to that object that collided with the attack
    
            //**THIS IS FOR DEMONSTRATION PURPOSES**
            if (!isAttacking && !mouseButtonHeld) {
                isAttacking = true;
                StartCoroutine(Debounce());
                if (playerMovement.sprite.flipX)
                {
                    Instantiate(weapon, new Vector2((-1) + transform.position.x, transform.position.y), weapon.transform.rotation).transform.SetParent(transform);
                    
                }
                else
                {
                    Instantiate(weapon, new Vector2(1 + transform.position.x, transform.position.y), weapon.transform.rotation).transform.SetParent(transform);
                }
                //Debug.Log(("no attack"));
            }
        }

        // check if the mouse is being held down
        if (Input.GetMouseButtonDown(0))
        {
            mouseButtonHeld = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseButtonHeld = false;
        }
    }

    // prevents attack spamming    
    IEnumerator Debounce()
    {
        yield return new WaitForSeconds(.25f);
        isAttacking = false;
        //Debug.Log("attack");
    }
}
