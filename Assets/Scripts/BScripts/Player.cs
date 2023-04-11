using UnityEngine;

public class Player : Character
{
    
    // this is for the SmoothDamp() function in 'CameraMovement.cs'
    [HideInInspector]
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    protected override void PlayDeathAnimation()
    {
        //Debug.Log("Player Death");
        float rotateDirection = 90f;
        // facing left
        if (GetIsFlipped())
        {
            rotateDirection *= -1;
        }
        
        gameObject.transform.RotateAround(transform.position, Vector3.forward, rotateDirection);

        // replace with a death animation
        //transform.GetComponent<Animator>().Play("Idle", 0);
        Destroy(gameObject.GetComponent<Animator>());

        // delete all action scripts
        Destroy(gameObject.GetComponent<PlayerMovement>());
        Destroy(gameObject.GetComponent<PlayerAttack>());
        Destroy(gameObject.GetComponent<PlayerDodge>());
    }
}
