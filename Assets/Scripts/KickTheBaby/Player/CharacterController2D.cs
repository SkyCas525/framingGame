using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    [SerializeField] float Speed=2f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    //Animator animator;
    public bool moving;


    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");



        motionVector = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")).normalized;

        //animator.SetFloat("horizontal", horizontal);
        //animator.SetFloat("vetical", vertical);

        //moving = horizontal != 0 || vertical != 0;
        //animator.SetBool("moving", moving);

        if (horizontal != 0 || vertical != 0 )
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;

            //animator.SetFloat("lastHorizontal", horizontal);
            //animator.SetFloat("lastVertical", vertical);
        }

    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rigidBody2D.velocity = motionVector * Speed; 
    }
}
