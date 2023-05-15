using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomEnemies : MonoBehaviour
{

    // array of all spawnable Enemies
    public GameObject[] enemyList;
    // the number of Enemies that will spawn
    public int spawnAmount;
    // time between spawns in seconds
    public float spawnTimeInterval;
    // how far away can the Enemy spawn from this object's X position
    private float xDistance;
    // how far away can the Enemy spawn from this object's Y position
    private float yDistance;
    private float spawnTimer = 0f;

    private void Start()
    {
        // all the possible spawn positions are based off the size of the object
        xDistance = transform.localScale.x / 2;
        yDistance = transform.localScale.y / 2;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnTimeInterval && spawnAmount > 0)
        {
            // choose a random X and Y position
            float xSpawn = Random.Range(-xDistance, xDistance);
            float ySpawn = Random.Range(-yDistance, yDistance);

            // set spawn location
            Vector3 spawnLocation = transform.position + new Vector3(xSpawn, ySpawn);

            // chooses a random Enemy from the list
            GameObject randomEnemy = enemyList[Random.Range(0, enemyList.Length)];

            Instantiate(randomEnemy, spawnLocation, randomEnemy.transform.rotation);

            spawnTimer = 0f;
            spawnAmount--;
        }

        // remove the spawner once it spawns all the Enemies
        if (spawnAmount == 0)
        {
            Destroy(gameObject);
        }
    }
}
