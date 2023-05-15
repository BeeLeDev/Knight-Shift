using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // damage the projectile does to the Character
    public int damage = 1;
    // speed in which the arrow travels
    public float projectileSpeed = 10f;
    private GameObject player;
    private Vector2 direction;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // want one direction, keeping it the same without changing
        direction = (player.transform.position - transform.position).normalized;

    }

    private void Update()
    {
        // Calculate the direction to the player

        // Rotate the arrow towards the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Move the arrow in the direction of the player
        transform.Translate(direction * projectileSpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // damage Player if it hits the Player
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Character>().TakeDamage(damage);
        }

        // it disappears once it touches something that is not an Enemy
        if (other.gameObject.tag != "RangedEnemy" && other.gameObject.tag != "MeleeEnemy")
        {
            Destroy(gameObject);
        }
    }
}

