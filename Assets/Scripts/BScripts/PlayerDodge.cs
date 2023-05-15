using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    // how much the Player moves when dodging
    public float translationAmount;
    // how much stamina dodging drains
    public int staminaDrain;

    private PlayerMovement playerMovement;
    private PlayerStamina playerStamina;
    private Animator animator;
    private bool rightMouseButtonHeld = false;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerStamina = GetComponent<PlayerStamina>();
        animator = GetComponent<Animator>();
    }

    /*
    TODO: Show the Player's current # of available dodges
    */

    // Update is called once per frame
    void Update()
    {
        // right click
        if (Input.GetMouseButtonDown(1))
        {
            // only dodge if the Player is currently not dodging, and not holding right click, and has enough stamina
            if (!GetIsDodging() && !rightMouseButtonHeld && playerStamina.GetStamina() >= staminaDrain)
            {
                rightMouseButtonHeld = true;
                SetIsDodging(1);
                playerStamina.DecreaseStamina(staminaDrain);
            }
        }

        // checks to see if the Player lifted mouse indicating they are not holding the left button
        if (Input.GetMouseButtonUp(1))
        {
            rightMouseButtonHeld = false;
        }
    }

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
        if (flag == 1)
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

    public void SetStaminaDrain(int staminaDrain)
    {
        this.staminaDrain = staminaDrain;
    }

    public int GetStaminaDrain()
    {
        return staminaDrain;
    }
}