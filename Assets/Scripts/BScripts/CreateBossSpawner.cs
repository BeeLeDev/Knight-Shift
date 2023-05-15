using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
THIS SCRIPT NEEDS A MORE GENERAL USE CASE, ITS SPECIFIC FOR TESTING FOR NOW
*/

public class CreateBossSpawner : MonoBehaviour
{
    public GameObject boss;
    public Vector3 position;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Player" && GameObject.FindGameObjectsWithTag("SpawnTrigger").Length == 1)
        {
            Instantiate(boss, position, boss.transform.rotation);
            GetComponent<BoxCollider2D>().enabled = false;
            //Destroy(gameObject);
        }
    }
}
