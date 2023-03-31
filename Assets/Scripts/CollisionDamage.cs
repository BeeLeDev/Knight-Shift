using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    // damage the collider does to Characters
    public int damage;
    private bool canDamage = true;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        //GameObject health = GameObject.Find("Health");
        other.gameObject.GetComponent<Character>().TakeDamage(1);
        Debug.Log(other.gameObject.GetComponent<Character>().health);
    }
}
