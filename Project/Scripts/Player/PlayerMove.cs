using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform groundPoint;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rigidbody2D;

    private float speed = 7f;
    private float jumpFroce = 8f;

    private float moveInpute;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = MoveVelosite();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private Collider2D Ground()
    {
        return Physics2D.OverlapCircle(groundPoint.position, .01f, groundLayer);
    }

    private void Jump()
    {
        if(Ground())
        { 
            rigidbody2D.velocity = Vector2.up * jumpFroce; 
        }
        
    }

    private Vector2 MoveVelosite()
    {
        moveInpute = Input.GetAxis("Horizontal");
        return new Vector2(moveInpute * speed, rigidbody2D.velocity.y);
    }
}  
