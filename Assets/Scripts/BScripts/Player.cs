using UnityEngine;

public class Player : Character
{
    
    // this is for the SmoothDamp() function in 'CameraMovement.cs'
    [HideInInspector]
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sprite = this.GetComponent<SpriteRenderer>();
        //playerDodge = this.GetComponent<PlayerDodge>();

        //health = 3;
        //damage = 1;
        //moveSpeed = 5.0f;
    }

    protected override void PlayDeathAnimation()
    {
        Debug.Log("Player Death");
        gameObject.transform.RotateAround(transform.position, Vector3.forward, -90f);
    }
}
