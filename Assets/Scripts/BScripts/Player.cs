using UnityEngine;

public class Player : Character
{
    
    // this is for the SmoothDamp() function in 'CameraMovement.cs'
    [HideInInspector]
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        health = 3;
        damage = 1;
        moveSpeed = 5.0f;
    }

    protected override void PlayDeathAnimation()
    {
        Debug.Log("Player Death");
        gameObject.transform.RotateAround(transform.position, Vector3.forward, -90f);
    }
}
