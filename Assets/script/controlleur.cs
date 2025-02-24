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

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
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
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            moveY = jumpForce;
        }
        rb.velocity = new Vector2(moveX, moveY);
    }
}