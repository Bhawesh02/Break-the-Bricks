using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BallController>() == null)
            return;
        /*if(playerController.NumOfBallsAvailable != playerController.MaxNumOfBalls)
            playerController.NumOfBallsAvailable++;*/
        Destroy(collision.gameObject);
    }
}
