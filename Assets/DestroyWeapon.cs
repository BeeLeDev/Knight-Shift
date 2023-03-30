using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWeapon : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitToRemoveWeapon());
    }

    IEnumerator WaitToRemoveWeapon()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
