using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    // damage the collider does to the Character
    public int damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Character>().TakeDamage(damage);
    }
}
