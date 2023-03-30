using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    private bool canDamage = true;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        //GameObject health = GameObject.Find("Health");
        if (canDamage)
        {
            StartCoroutine(DamageBuffer());
            canDamage = false;
            --other.gameObject.GetComponent<Player>().health;
        }
        Debug.Log(other.gameObject.GetComponent<Player>().health);
    }

    IEnumerator DamageBuffer()
    {
        yield return new WaitForSeconds(1);
        canDamage = true;
    }
}
