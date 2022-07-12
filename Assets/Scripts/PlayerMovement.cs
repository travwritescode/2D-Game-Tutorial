using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private float dirX;
    //SerializeField exposes these fields to the Unity editor
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * dirX, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState(dirX);
    }

    private void UpdateAnimationState(float dirX)
    {
        if (dirX > 0f)
        {
            animator.SetBool("running", true);
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0f)
        {
            animator.SetBool("running", true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool("running", false);
        }

    }
}
