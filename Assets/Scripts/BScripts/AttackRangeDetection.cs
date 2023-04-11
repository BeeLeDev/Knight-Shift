using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeDetection : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player in range");
            gameObject.GetComponentInParent<EnemyAttack>().playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player no longer in range");
            gameObject.GetComponentInParent<EnemyAttack>().playerInRange = false;
        }
    }
}
