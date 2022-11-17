using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rgbd2D;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.5f;



    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 position;

    }


    
}
