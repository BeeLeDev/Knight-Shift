using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : MonoBehaviour
{
    
    // the name of the buff
    private string buffName = "None";

    public void SetBuff(string buffName)
    {
        this.buffName = buffName;
        updateBuff();
        Debug.Log(buffName);
    }

    // adds the buff during the run
    public void updateBuff() {

        // heals and adds extra health
        if (buffName == "Extra Health") {
            int x = GetComponent<Player>().GetHealth();
            x += 2;
            GetComponent<Player>().SetHealth(x);
        }

        // heals and multiplies health
        if (buffName == "Health Surge") {
            int x = GetComponent<Player>().GetHealth();
            x *= 2;
            GetComponent<Player>().SetHealth(x);
        }

        // adds extra damage
        if (buffName == "Extra Damage") {
            int x = GetComponent<Player>().GetDamage();
            x += 1;
            GetComponent<Player>().SetDamage(x);
        }

        // multiplies damage
        if (buffName == "Forceful Strike") {
            int x = GetComponent<Player>().GetDamage();
            x *= 2;
            GetComponent<Player>().SetDamage(x);
        }

        // adds extra speed
        if (buffName == "Faster Movement") {
            float x = GetComponent<Player>().GetMoveSpeed();
            x += 1f;
            GetComponent<Player>().SetMoveSpeed(x);
        }

        // increases total stamina
        if (buffName == "Extra Stamina") {
            int x = GetComponent<PlayerStamina>().GetMaxStamina();
            x += 25;
            GetComponent<PlayerStamina>().SetMaxStamina(x);
        }

        // decreases stamina cost to roll
        if (buffName == "Light Roll") {
            int x = GetComponent<PlayerDodge>().GetDrain();
            if (x > 5) {
                x += -5;
            }
            GetComponent<PlayerDodge>().SetDrain(x);
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

            int y = GetComponent<Player>().GetDamage();
            y += 5;
            GetComponent<Player>().SetDamage(y);
        }

        // increases health but slows player down
        if (buffName == "Armored Warrior") {
            int x = GetComponent<Player>().GetHealth();
            x *= 3;
            GetComponent<Player>().SetHealth(x);

            float y = GetComponent<Player>().GetMoveSpeed();
            y = y/2f;
            GetComponent<Player>().SetMoveSpeed(y);
        }

        // increases speed but weakens player
        if (buffName == "Nimble Warrior") {
            int x = GetComponent<Player>().GetHealth();
            x = (int) x/2;
            GetComponent<Player>().SetHealth(x);

            float y = GetComponent<Player>().GetMoveSpeed();
            y *= 3f;
            GetComponent<Player>().SetMoveSpeed(y);
        }

        // increases damage but slows player down
        if (buffName == "Heavy Blade") {
            int x = GetComponent<Player>().GetDamage();
            x *= 3;
            GetComponent<Player>().SetDamage(x);

            float y = GetComponent<Player>().GetMoveSpeed();
            y = y/2f;
            GetComponent<Player>().SetMoveSpeed(y);
        }

        // decreases damage but speeds player up
        if (buffName == "Light Blade") {
            int x = GetComponent<Player>().GetDamage();
            x = (int) x/2;
            GetComponent<Player>().SetDamage(x);

            float y = GetComponent<Player>().GetMoveSpeed();
            y *= 3f;
            GetComponent<Player>().SetMoveSpeed(y);
        }

        // increased health, damage, and speed
        if (buffName == "Super Surge") {
            int x = GetComponent<Player>().GetHealth();
            x += 5;
            GetComponent<Player>().SetHealth(x);

            float y = GetComponent<Player>().GetMoveSpeed();
            y += 5f;
            GetComponent<Player>().SetMoveSpeed(y);

            int z = GetComponent<Player>().GetDamage();
            z += 5;
            GetComponent<Player>().SetDamage(z);
        }

        // 1 shot yourself, and 1 shot them
        if (buffName == "Last Stand") {
            GetComponent<Player>().SetHealth(1);
            GetComponent<Player>().SetDamage(100);
        }



    }

    // resets the buffs once player dies and returns to the main hub
    public void resetAll() {
        GetComponent<Player>().SetHealth(3);
        GetComponent<Player>().SetDamage(1);
        GetComponent<Player>().SetMoveSpeed(3.5f);
        GetComponent<PlayerAttack>().SetStaminaDrain(10);
        GetComponent<PlayerDodge>().SetDrain(35);
        GetComponent<PlayerStamina>().SetMaxStamina(100);
    }
}
