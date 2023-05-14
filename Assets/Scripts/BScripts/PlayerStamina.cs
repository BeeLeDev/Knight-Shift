using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    // i can use the dodge restoration mechanic i created to do stamina instead

    public int maxStamina = 100;
    // points of stamina being restored every (restoreTimer #) seconds
    public int restoreAmount = 1;
    // timer in seconds to restore (restoreInterval #) points of stamina
    // using 0.14 specifically as dodging takes 35 points, and we want them to be able to dodge every 5 seconds, so 1 point every 0.14 seconds will give 35 points in 5 seconds
    // this will porbably change overtime
    public float restoreInterval = 0.14f;
    // time it takes in seconds to allow the start of stamina restoring after using an action
    public float restoreDelay = 1.5f;

    private PlayerAttack playerAttack;
    private PlayerDodge playerDodge;
    // change to public to test when running game
    // set to private when not testing
    private int currentStamina;
    private float restoreTimer = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerDodge = GetComponent<PlayerDodge>();
        currentStamina = maxStamina; 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStamina < maxStamina)
        {
            restoreTimer += Time.deltaTime;

            // delay restoring stamina if an action was used
            if (playerAttack.GetIsAttacking() || playerDodge.GetIsDodging())
            {
                restoreTimer = 0 - restoreDelay;
            }

            // only restore every (restoreTimer #) of seconds
            if (restoreTimer >= restoreInterval)
            {
                IncreaseStamina(restoreAmount);
                restoreTimer = 0;  
            }
        }
    }

    public int GetMaxStamina() 
    {
        return maxStamina;
    }

    public void SetMaxStamina(int maxStamina) 
    {
        this.maxStamina = maxStamina;
    }

    public int GetStamina()
    {
        return currentStamina;
    }

    public void SetStamina(int stamina)
    {
        currentStamina = stamina;

        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
        else if (currentStamina < 0)
        {
            currentStamina = 0;
        }
    }

    public void IncreaseStamina(int increaseAmount)
    {
        SetStamina(GetStamina() + increaseAmount);
    }

    public void DecreaseStamina(int decreaseAmount)
    {
        SetStamina(GetStamina() - decreaseAmount);
    }
}
