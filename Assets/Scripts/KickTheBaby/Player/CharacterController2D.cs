using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [SerializeField] public Vector2 direction;

    public static Transform player;

    Vector2 motionVector;
    public Vector2 lastMotionVector;

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
        motionVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (xDir != 0||yDir !=0 )
        {
            lastMotionVector = new Vector2(xDir,yDir).normalized;
        }











        //---------------------------------------------------------------------------------------------------
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

        if (direction.y < 0)
        {
            spriteRenderer.flipY = false;
            spriteRenderer.flipX = false;
        }
        if (direction.y > 0)
        {
            spriteRenderer.flipY = true;
            spriteRenderer.flipX = false;
        }




    }

    private void FixedUpdate()
    {
        RB2D.MovePosition(RB2D.position + direction * movementSpeed * Time.fixedDeltaTime);

    }



}
