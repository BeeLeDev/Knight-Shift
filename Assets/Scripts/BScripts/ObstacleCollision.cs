using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    // damage the collider does to Characters
    public int damage;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        //GameObject health = GameObject.Find("Health");
        other.gameObject.GetComponent<Character>().TakeDamage(damage);
        Debug.Log(other.gameObject.GetComponent<Character>().health);
    }
}
