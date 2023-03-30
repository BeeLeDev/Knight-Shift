using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        base.rb = GetComponent<Rigidbody2D>();
        base.sprite = GetComponent<SpriteRenderer>();
        health = 3;
        moveSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
