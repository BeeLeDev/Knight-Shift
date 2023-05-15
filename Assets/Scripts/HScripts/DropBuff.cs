using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBuff : MonoBehaviour
{
    public GameObject buff;

    public void Drop() 
    {
        // range from 1 (inclusive) - 100 (101 exlusive)
        int x = Random.Range(1, 101);
        if (x <= 15) {
            Instantiate(buff, transform.position, buff.transform.rotation);
        }
    }
}
