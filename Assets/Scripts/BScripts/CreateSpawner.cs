using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
THIS SCRIPT NEEDS A MORE GENERAL USE CASE, ITS SPECIFIC FOR TESTING FOR NOW
*/

public class CreateSpawner : MonoBehaviour
{
    public GameObject spawner;
    public Vector3 position;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(spawner, position, spawner.transform.rotation);
            Destroy(gameObject);
        }
    }
}
