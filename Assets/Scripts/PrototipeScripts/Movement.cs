using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [SerializeField] private Vector2 direction;

    public static Transform player;

    private Rigidbody2D RB2D;
    SpriteRenderer spriteRenderer;

    float xDir;
    float yDir;
    private Animator animator;

    private void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        yDir = Input.GetAxisRaw("Vertical");

        animator.SetFloat("xDir", xDir);
        animator.SetFloat("yDir", yDir);

        direction = new Vector2(xDir, yDir).normalized;

        if (xDir != 0 || yDir != 0)
        {
            animator.SetFloat("lastX", xDir);
            animator.SetFloat("lastY", yDir);
        }


        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }




    }

    private void FixedUpdate()
    {
        RB2D.MovePosition(RB2D.position + direction * movementSpeed * Time.fixedDeltaTime);
    }
}
