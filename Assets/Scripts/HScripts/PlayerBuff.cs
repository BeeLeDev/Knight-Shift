using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBuff : MonoBehaviour
{
    public TextMeshProUGUI buffMessage;

    // the name of the buff
    private string buffName = "None";
    // intial value of Player's stats
    private Hashtable defaultStats;
    // we don't need this, just using it to shorten lines of code
    private Player player;

    private void Start() 
    {
        player = GetComponent<Player>();
        buffMessage.enabled = false;

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

    public void DisableText() 
    {
        buffMessage.enabled = false;
    }

    // adds the buff during the run
    public void UpdateBuff() {

        // heals and adds extra health
        if (buffName == "Extra Health") {
            buffMessage.text = "Health Increased";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            int x = player.GetHealth();
            x += 2;
            player.SetHealth(x);
        }

        // heals and multiplies health
        if (buffName == "Health Surge") {
            buffMessage.text = "Health Increased Greatly";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            int x = player.GetHealth();
            x *= 2;
            player.SetHealth(x);
        }

        // adds extra damage
        if (buffName == "Extra Damage") {
            buffMessage.text = "Damage Increased";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            int x = player.GetDamage();
            x += 1;
            player.SetDamage(x);
        }

        // multiplies damage
        if (buffName == "Forceful Strike") {
            buffMessage.text = "Damage Increased Greatly";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            int x = player.GetDamage();
            x *= 2;
            player.SetDamage(x);
        }

        // adds extra speed
        if (buffName == "Faster Movement") {
            buffMessage.text = "Speed Increased";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            float x = player.GetMoveSpeed();
            x += 0.25f;
            player.SetMoveSpeed(x);
        }

        // increases total stamina
        if (buffName == "Extra Stamina") {
            buffMessage.text = "Stamina Increased";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            int x = GetComponent<PlayerStamina>().GetMaxStamina();
            x += 25;
            GetComponent<PlayerStamina>().SetMaxStamina(x);
        }

        // decreases stamina cost to roll
        if (buffName == "Light Roll") {
            buffMessage.text = "Stamina Cost for Roll Reduced";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            int x = GetComponent<PlayerDodge>().GetStaminaDrain();
            if (x > 5) {
                x += -5;
            }
            GetComponent<PlayerDodge>().SetStaminaDrain(x);
        }

        // decreases stamina cost to attack
        if (buffName == "Light Strike") {
            buffMessage.text = "Stamina Cost for Attack Reduced";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            int x = GetComponent<PlayerAttack>().GetStaminaDrain();
            if (x > 2) {
                x += -2;
            }
            GetComponent<PlayerAttack>().SetStaminaDrain(x);
        }

        // increases stamina cost but increases damage of swing greatly
        if (buffName == "Weighted Blade") {
            buffMessage.text = "Increased Damage, Increased Stamina Drain on Hit";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            int x = GetComponent<PlayerAttack>().GetStaminaDrain();
            x += 5;
            GetComponent<PlayerAttack>().SetStaminaDrain(x);

            int y = player.GetDamage();
            y += 3;
            player.SetDamage(y);
        }

        // increases health but slows player down
        if (buffName == "Armored Warrior") {
            buffMessage.text = "Greatly Increased Health, Greatly Decreased Speed";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            int x = player.GetHealth();
            x *= 3;
            player.SetHealth(x);

            float y = player.GetMoveSpeed();
            y = y/2f;
            player.SetMoveSpeed(y);
        }

        // increases speed but weakens player
        if (buffName == "Nimble Warrior") {
            buffMessage.text = "Greatly Decreased Health, Greatly Increased Speed";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            int x = player.GetHealth();
            x = (int) x/2;
            player.SetHealth(x);

            float y = player.GetMoveSpeed();
            y *= 1.25f;
            player.SetMoveSpeed(y);
        }

        // increases damage but slows player down
        if (buffName == "Heavy Blade") {
            buffMessage.text = "Greatly Increased Damage, Greatly Decreased Speed";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            int x = player.GetDamage();
            x *= 3;
            player.SetDamage(x);

            float y = player.GetMoveSpeed();
            y = y/2f;
            player.SetMoveSpeed(y);
        }

        // decreases damage but speeds player up
        if (buffName == "Light Blade") {
            buffMessage.text = "Greatly Decreased Damage, Greatly Increased Speed";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            int x = player.GetDamage();
            x = (int) x/2;
            player.SetDamage(x);

            float y = player.GetMoveSpeed();
            y *= 1.25f;
            player.SetMoveSpeed(y);
        }

        // increased health, damage, and speed
        if (buffName == "Super Surge") {
            buffMessage.text = "Increased Health, Speed, and Damage";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
            int x = player.GetHealth();
            x += 5;
            player.SetHealth(x);

            float y = player.GetMoveSpeed();
            y += 1.5f;
            player.SetMoveSpeed(y);

            int z = player.GetDamage();
            z += 5;
            player.SetDamage(z);
        }

        // 1 shot yourself, and 1 shot them
        if (buffName == "Last Stand") {
            buffMessage.text = "Last Stand, Massively Increased Damage, Massively Decreased Health";
            buffMessage.enabled = true;
            Invoke("DisableText", 3);
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
