using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : MonoBehaviour
{
    // the name of the buff
    private string buffName = "None";
    // intial value of Player's stats
    private Hashtable defaultStats;
    // we don't need this, just using it to shorten lines of code
    private Player player;

    private void Start() 
    {
        player = GetComponent<Player>();

        defaultStats = new Hashtable();
        defaultStats.Add("Health", player.GetHealth());
        defaultStats.Add("Damage", player.GetDamage());
        defaultStats.Add("MoveSpeed", player.GetMoveSpeed());
        defaultStats.Add("StaminaDrainAttack", GetComponent<PlayerAttack>().GetStaminaDrain());
        defaultStats.Add("StaminaDrainDodge", GetComponent<PlayerDodge>().GetStaminaDrain());
        defaultStats.Add("MaxStamina", GetComponent<PlayerStamina>().GetMaxStamina());
    }

    public void SetBuff(string buffName)
    {
        this.buffName = buffName;
        UpdateBuff();
        Debug.Log(buffName);
    }

    // adds the buff during the run
    public void UpdateBuff() {

        // heals and adds extra health
        if (buffName == "Extra Health") {
            int x = player.GetHealth();
            x += 2;
            player.SetHealth(x);
        }

        // heals and multiplies health
        if (buffName == "Health Surge") {
            int x = player.GetHealth();
            x *= 2;
            player.SetHealth(x);
        }

        // adds extra damage
        if (buffName == "Extra Damage") {
            int x = player.GetDamage();
            x += 1;
            player.SetDamage(x);
        }

        // multiplies damage
        if (buffName == "Forceful Strike") {
            int x = player.GetDamage();
            x *= 2;
            player.SetDamage(x);
        }

        // adds extra speed
        if (buffName == "Faster Movement") {
            float x = player.GetMoveSpeed();
            x += 1f;
            player.SetMoveSpeed(x);
        }

        // increases total stamina
        if (buffName == "Extra Stamina") {
            int x = GetComponent<PlayerStamina>().GetMaxStamina();
            x += 25;
            GetComponent<PlayerStamina>().SetMaxStamina(x);
        }

        // decreases stamina cost to roll
        if (buffName == "Light Roll") {
            int x = GetComponent<PlayerDodge>().GetStaminaDrain();
            if (x > 5) {
                x += -5;
            }
            GetComponent<PlayerDodge>().SetStaminaDrain(x);
        }

        // decreases stamina cost to attack
        if (buffName == "Light Strike") {
            int x = GetComponent<PlayerAttack>().GetStaminaDrain();
            if (x > 2) {
                x += -2;
            }
            GetComponent<PlayerAttack>().SetStaminaDrain(x);
        }

        // increases stamina cost but increases damage of swing greatly
        if (buffName == "Weighted Blade") {
            int x = GetComponent<PlayerAttack>().GetStaminaDrain();
            x += 5;
            GetComponent<PlayerAttack>().SetStaminaDrain(x);

            int y = player.GetDamage();
            y += 5;
            player.SetDamage(y);
        }

        // increases health but slows player down
        if (buffName == "Armored Warrior") {
            int x = player.GetHealth();
            x *= 3;
            player.SetHealth(x);

            float y = player.GetMoveSpeed();
            y = y/2f;
            player.SetMoveSpeed(y);
        }

        // increases speed but weakens player
        if (buffName == "Nimble Warrior") {
            int x = player.GetHealth();
            x = (int) x/2;
            player.SetHealth(x);

            float y = player.GetMoveSpeed();
            y *= 3f;
            player.SetMoveSpeed(y);
        }

        // increases damage but slows player down
        if (buffName == "Heavy Blade") {
            int x = player.GetDamage();
            x *= 3;
            player.SetDamage(x);

            float y = player.GetMoveSpeed();
            y = y/2f;
            player.SetMoveSpeed(y);
        }

        // decreases damage but speeds player up
        if (buffName == "Light Blade") {
            int x = player.GetDamage();
            x = (int) x/2;
            player.SetDamage(x);

            float y = player.GetMoveSpeed();
            y *= 3f;
            player.SetMoveSpeed(y);
        }

        // increased health, damage, and speed
        if (buffName == "Super Surge") {
            int x = player.GetHealth();
            x += 5;
            player.SetHealth(x);

            float y = player.GetMoveSpeed();
            y += 5f;
            player.SetMoveSpeed(y);

            int z = player.GetDamage();
            z += 5;
            player.SetDamage(z);
        }

        // 1 shot yourself, and 1 shot them
        if (buffName == "Last Stand") {
            player.SetHealth(1);
            player.SetDamage(100);
        }



    }

    // resets the buffs once player dies and returns to the main hub
    public void resetAll() {
        player.SetHealth((int)defaultStats["Health"]);
        player.SetDamage((int)defaultStats["Damage"]);
        player.SetMoveSpeed((int)defaultStats["MoveSpeed"]);
        GetComponent<PlayerAttack>().SetStaminaDrain((int)defaultStats["StaminaDrainAttack"]);
        GetComponent<PlayerDodge>().SetStaminaDrain((int)defaultStats["StaminaDrainDodge"]);
        GetComponent<PlayerStamina>().SetMaxStamina((int)defaultStats["NaxStamina"]);
    }
}
