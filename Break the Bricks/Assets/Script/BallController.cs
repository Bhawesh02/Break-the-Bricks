using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;

    Vector2 lastVelocity;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            float speed = lastVelocity.magnitude;
            Vector2 direction = Vector2.Reflect(lastVelocity.normalized,collision.GetContact(0).normal);
            rb.velocity = direction * speed;
         

    }
}
