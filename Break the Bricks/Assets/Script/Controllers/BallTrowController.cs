
using UnityEngine;

public class BallTrowController : MonoBehaviour
{
    [SerializeField]
    private GameObject Ball;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private GameObject Balls;

    private BoxCollider2D boxCollider;

    private SpriteRenderer spriteRenderer;

    private SpriteRenderer ballSpriteRenderer;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ballSpriteRenderer = Ball.GetComponent<SpriteRenderer>();
    }
    public void SpawnBall(float releaseAngle)
    {
        float NewBallY = transform.position.y + (spriteRenderer.bounds.size.y / 2) + (ballSpriteRenderer.bounds.size.y);
        Vector2 NewBallPos = new(transform.position.x, NewBallY);
        GameObject NewBall=Instantiate(Ball, NewBallPos, Ball.transform.rotation,Balls.transform);
        Vector2 ReleaseVector = Quaternion.Euler(0, 0, releaseAngle) * Vector2.right;
        NewBall.GetComponent<Rigidbody2D>().velocity = ReleaseVector * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BallController>() == null)
            return;
        PlayerController playerController = GameManager.Instance.playerController;
        if (playerController.NumOfBallsAvailable != playerController.MaxNumOfBalls)
            playerController.NumOfBallsAvailable++;
        Destroy(collision.gameObject);
    }
}
