using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    Vector2 movement;

    bool isRight = true;
    bool isLeft;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y =Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x > 0.01f || movement.y > 0.01f)
        {
            animator.ResetTrigger("isLeft");
            animator.SetTrigger("isRight");
            isRight = true;
            isLeft = false;
        }
        if (movement.x < -0.01f || movement.y < -0.01f)
        {
            animator.ResetTrigger("isRight");
            animator.SetTrigger("isLeft");
            isRight = false;
            isLeft = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && isRight)
        {
            animator.SetTrigger("attackRight");
        }
        if (Input.GetKeyDown(KeyCode.E) && isLeft)
        {
            animator.SetTrigger("attackLeft");
        }

        if (Input.GetKeyDown(KeyCode.Q) && isRight)
        {
            animator.SetTrigger("rollRight");
        }
        if (Input.GetKeyDown(KeyCode.Q) && isLeft)
        {
            animator.SetTrigger("rollLeft");
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
