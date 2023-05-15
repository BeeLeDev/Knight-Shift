using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
THIS SCRIPT NEEDS A MORE GENERAL USE CASE, ITS SPECIFIC FOR TESTING FOR NOW
*/

public class SpawnBoss : MonoBehaviour
{
    public GameObject boss;
    public Vector3 position;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && GameObject.FindGameObjectsWithTag("SpawnTrigger").Length == 1)
        {
            Instantiate(boss, position, boss.transform.rotation);
            Destroy(gameObject);
        }
    }
}
