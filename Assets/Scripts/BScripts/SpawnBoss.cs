using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public List<GameObject> requiredEnemies;
    public GameObject boss;

    private int enemiesKilled;

    // Update is called once per frame
    void Update()
    { 
        for (int i = 0; i < requiredEnemies.Count; i++)
        {
            if (requiredEnemies[i] == null)
            {
                // Remove the null reference from the list
                requiredEnemies.RemoveAt(i);
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
