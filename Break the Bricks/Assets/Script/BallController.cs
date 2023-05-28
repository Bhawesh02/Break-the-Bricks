using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CheckWallCollision();
    }
    private void CheckWallCollision()
    {
        Vector2 position = transform.position;
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(position);

        if (viewportPosition.x <= 0 || viewportPosition.x >= 1)
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }

        if (viewportPosition.y <= 0 || viewportPosition.y >= 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
    }
}
