
using UnityEngine;

public class BallTrowController : MonoBehaviour
{
    [SerializeField]
    private GameObject Ball;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private GameObject Balls;

    public void SpawnBall(float releaseAngle)
    {
        GameObject NewBall=Instantiate(Ball,transform.position,Ball.transform.rotation,Balls.transform);
        Vector2 ReleaseVector = Quaternion.Euler(0, 0, releaseAngle) * Vector2.right; 
        NewBall.GetComponent<Rigidbody2D>().velocity = ReleaseVector * speed;
        
    }    
}
