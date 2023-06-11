using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;

    public float speed = 5f;
    public float fireRate = 0.25f;
    public bool CanGoLeft;
    public bool CanGoRight;
    [SerializeField]
    private ArrowController arrow;
    [SerializeField]
    private BallTrowController trowController;
    [SerializeField]
    private GameObject leftCollider;
    [SerializeField]
    private GameObject rightCollider;
    public uint MaxNumOfBalls;
    public uint NumOfBallsAvailable;
 
    private float nextFireTime;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        CanGoLeft = true;
        CanGoRight = true;
        NumOfBallsAvailable = MaxNumOfBalls;
    }
    private void Start()
    {
        GameManager.Instance.playerController = this;
        nextFireTime = Time.time;
        StopPlayerMovement left = leftCollider.GetComponent<StopPlayerMovement>();
        left.platformCollider = PlatformCollider.Left;
        left.playerController = this;
        StopPlayerMovement right = rightCollider.GetComponent<StopPlayerMovement>();
        right.platformCollider = PlatformCollider.Right;
        right.playerController = this;

    }
    void Update()
    {
        PlayerMovement();
        FireBall();
    }

    private void FireBall()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime && (NumOfBallsAvailable != 0))
        {
            trowController.SpawnBall(arrow.Angle);
            NumOfBallsAvailable--;
            nextFireTime = Time.time + fireRate;
        }
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A) && CanGoLeft)
            transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);
        if (Input.GetKey(KeyCode.D) && CanGoRight)
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
    }
}

public enum PlatformCollider
{
    Left,
    Right
}


