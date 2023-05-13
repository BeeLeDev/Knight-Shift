using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public List<GameObject> requiredEnemies;
    public GameObject boss;

    private int enemiesKilled;

    private void Start() 
    {
        // this assumes the EnemySpawners spawn Enemies at the start of the game
        // what if we want to spawn the enemies when the Player triggers something?
        GameObject[] meleeEnemies = GameObject.FindGameObjectsWithTag("MeleeEnemy");
        GameObject[] rangedEnemies = GameObject.FindGameObjectsWithTag("RangedEnemy");

        foreach (GameObject meleeEnemy in meleeEnemies)
        {
            requiredEnemies.Add(meleeEnemy);
        }

        foreach (GameObject rangedEnemy in rangedEnemies)
        {
            requiredEnemies.Add(rangedEnemy);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        foreach (GameObject enemy in requiredEnemies)
        {
            if (enemy == null)
            {
                // remove the null reference from the list
                requiredEnemies.Remove(enemy);
            }
        }

        if (requiredEnemies.Count == 0)
        {
            // spawn boss
            Instantiate(boss, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
