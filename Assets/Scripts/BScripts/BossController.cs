using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
  
    public GameObject spinHitbox;
    public GameObject explosionHitbox;
    public GameObject specialHitbox;
    private GameObject existingHitbox;

    private void CreateSpinHitbox()
    {
        existingHitbox = Instantiate(spinHitbox, new Vector3(transform.position.x + (-0.037f) , transform.position.y + (-1.424f), 0), spinHitbox.transform.rotation);
            
        // facing left
        if (GetComponent<Enemy>().GetIsFlipped())
        {
            existingHitbox.transform.RotateAround(transform.position, Vector3.up, 180f);
        }
    }

    private void CreateExplosionHitbox()
    {
        existingHitbox = Instantiate(explosionHitbox, new Vector3(transform.position.x + (1.425f) , transform.position.y + (-1.044f), 0), explosionHitbox.transform.rotation);
            
        // facing left
        if (GetComponent<Enemy>().GetIsFlipped())
        {
            existingHitbox.transform.RotateAround(transform.position, Vector3.up, 180f);
        }
    }

    private void CreateSpecialHitbox()
    {
        existingHitbox = Instantiate(specialHitbox, new Vector3(transform.position.x + (1.9f) , transform.position.y + (-1.31f), 0), specialHitbox.transform.rotation);
            
        // facing left
        if (GetComponent<Enemy>().GetIsFlipped())
        {
            existingHitbox.transform.RotateAround(transform.position, Vector3.up, 180f);
        }
    }

    private void DeleteBossHitbox()
    {
        // if a hitbox exists, destroy it
        if (existingHitbox)
        {
            Destroy(existingHitbox);
        }
    }
}
