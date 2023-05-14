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
        if (buffName == "Extra Health") {
            int x = GetComponent<Player>().GetHealth();
            x += 2;
            GetComponent<Player>().SetHealth(x);
        }
        if (buffName == "Extra Damage") {
            int x = GetComponent<Player>().GetDamage();
            x += 1;
            GetComponent<Player>().SetDamage(x);
        }
        if (buffName == "Faster Movement") {
            float x = GetComponent<Player>().GetMoveSpeed();
            x += 1f;
            GetComponent<Player>().SetMoveSpeed(x);
        }
    }

    // resets the buffs once player dies and returns to the main hub
    public void resetAll() {
        GetComponent<Player>().SetHealth(3);
        GetComponent<Player>().SetDamage(1);
        GetComponent<Player>().SetMoveSpeed(3.5f);
    }
}
