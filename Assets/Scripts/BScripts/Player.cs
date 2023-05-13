using UnityEngine;

public class Player : Character
{
    public AudioSource source;
    public AudioClip clip;


    // this is for the SmoothDamp() function in 'CameraMovement.cs'
    [HideInInspector]
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public override void TakeDamage(int damage)
    {
        // if the Player is dodging, do not let them take damage 
        if (!GetComponent<Animator>().GetBool("isDodging"))
        {
            SetHealth(GetHealth() - damage);
            StartCoroutine(OnHit());
            source.clip = clip;
            source.Play();
        }

        // when Player dodges the hit flag is not returned to false as it is changed when OnHit() is called
        hitFlag = false;
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
        
        transform.RotateAround(transform.position, Vector3.forward, rotateDirection);

        // replace with a death animation
        //transform.GetComponent<Animator>().Play("Idle", 0);
        Destroy(GetComponent<Animator>());

        // delete all action scripts
        Destroy(GetComponent<PlayerMovement>());
        Destroy(GetComponent<PlayerAttack>());
        Destroy(GetComponent<PlayerDodge>());
    }
}
