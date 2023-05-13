using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    // name of the buff
    public string buffName;

    // List of all buffs
    public string[] buffNames = {"Extra Health", "Extra Damage" , "Faster Movement"};

    private void OnCollisionEnter2D(Collision2D other) 
    {
        // chooses a random buff from the list
        buffName = buffNames[Random.Range(0, buffNames.Length)];

        // sets buff in other script
        other.gameObject.GetComponent<PlayerBuff>().SetBuff(buffName);

        // destroys the sphere
        Destroy(gameObject);
    }
}