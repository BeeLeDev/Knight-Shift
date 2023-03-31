using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        //GameObject health = GameObject.Find("Health");
        Debug.Log(other.gameObject.name);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
