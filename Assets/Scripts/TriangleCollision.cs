using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject health = GameObject.Find("Health");
        }
    }

}
