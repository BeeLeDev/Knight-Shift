using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    // name of the buff
    public string buffName;

    // List of all buffs
    private string[] buffNames = {"Extra Health", "Extra Damage" , "Faster Movement" , "Extra Stamina" , "Light Roll" , "Light Strike" , "Forceful Strike" , "Health Surge" , 
    "Weighted Blade", "Armored Warrior" , "Nimble Warrior", "Heavy Blade", "Light Blade" , "Super Surge" , "Last Stand"};

    private void Start() 
    {
        // chooses a random buff from the list
        buffName = buffNames[Random.Range(0, buffNames.Length)];
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        // sets buff in other script
        other.gameObject.GetComponent<PlayerBuff>().SetBuff(buffName);

        // destroys the sphere
        Destroy(gameObject);
    }
}