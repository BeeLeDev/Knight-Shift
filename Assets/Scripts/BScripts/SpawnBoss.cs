using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject boss;
    public Vector3 position;

    // Update is called once per frame
    void Update()
    { 
        // if there are no spawner & enemies left, spawn the boss
        if (
            GameObject.FindGameObjectsWithTag("MeleeEnemy").Length == 0 && 
            GameObject.FindGameObjectsWithTag("RangedEnemy").Length == 0 &&
            GameObject.FindGameObjectsWithTag("SpawnTrigger").Length == 0)
        {
            // spawn boss
            Instantiate(boss, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
