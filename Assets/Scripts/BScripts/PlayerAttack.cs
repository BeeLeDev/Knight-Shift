using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject attackHitbox;
    // how much stamina dodging drains
    public int staminaDrain;
    
    private GameObject existingHitbox;
    private PlayerStamina playerStamina;
    private Animator animator;
    private bool leftMouseButtonHeld = false;

    private void Start() {
        playerStamina = GetComponent<PlayerStamina>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // left click
        if (Input.GetMouseButtonDown(0))
        {
            // check if the hitbox collided with anything
            // if so deal damage to that object that collided with the attack
            if (!GetIsAttacking() && !leftMouseButtonHeld && playerStamina.GetStamina() >= staminaDrain) 
            {
                leftMouseButtonHeld = true;
                SetIsAttacking(1);
                playerStamina.DecreaseStamina(staminaDrain);
            }
        }

        // checks to see if the Player lifted mouse indicating they are not holding the left button
        if (Input.GetMouseButtonUp(0))
        {
            leftMouseButtonHeld = false;
        }
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

    // used in event function
    private void CreateHitbox()
    {
        // facing left
        if (GetComponent<Player>().GetIsFlipped())
        {
            // hitbox.transform.RotateAround(hitbox.transform.position, Vector3.right, 180f);
            existingHitbox = Instantiate(attackHitbox, new Vector3(transform.position.x - (0.578f), transform.position.y + (0.043f), 0), attackHitbox.transform.rotation);

            existingHitbox.transform.RotateAround(existingHitbox.transform.position, Vector3.up, 180f);
        }
        // facing right
        else
        {
            existingHitbox = Instantiate(attackHitbox, new Vector3(transform.position.x + (0.578f) , transform.position.y + (0.043f), 0), attackHitbox.transform.rotation);
        }
    }

    // used in event function
    private void DeleteHitbox()
    {
        // if a hitbox exists, destroy it
        if (existingHitbox)
        {
            Destroy(existingHitbox);
        }
    }

    public void SetStaminaDrain(int staminaDrain) 
    {
        this.staminaDrain = staminaDrain;
    }

    public int GetStaminaDrain() 
    {
        return staminaDrain;
    }
}