using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    [SerializeField] float Speed=2f;
    Vector2 motionVector;


    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        motionVector = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")).normalized;
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
