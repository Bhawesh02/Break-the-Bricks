using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour
{
    public PlatformCollider platformCollider;
    public PlayerController playerController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Wall"))
            return;
        if (platformCollider == PlatformCollider.Left)
        {
            playerController.CanGoLeft = false;
            return;
        }
        playerController.CanGoRight = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Wall"))
            return;
        playerController.CanGoLeft = playerController.CanGoRight = true;

    }

}
