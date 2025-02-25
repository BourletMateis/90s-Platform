using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 2f;
    public float jumpForce = 7f;
    private bool isGrounded;
    public Transform groundCheck; 
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GameObject.Find("GroundCheck").transform;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float moveX = 0f;
        float moveY = rb.velocity.y;

        if (Input.GetKey(KeyCode.D))
        {
            moveX = speed;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            moveX = -speed;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            moveY = jumpForce;
        }

        rb.velocity = new Vector2(moveX, moveY);
    }

    void FixedUpdate()
    {
        OnGround();
    }

    void OnGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}