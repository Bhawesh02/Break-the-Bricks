using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float fireRate = 0.25f;
    [SerializeField]
    private ArrowController arrow;
    [SerializeField]
    private BallTrowController trowController;
    private float nextFireTime;
    // Update is called once per frame
    private void Start()
    {
        nextFireTime = Time.time;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.position = new Vector3(transform.position.x -(speed * Time.deltaTime),transform.position.y,transform.position.z);
        if (Input.GetKey(KeyCode.D))
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            trowController.SpawnBall(arrow.Angle);
            nextFireTime = Time.time + fireRate;
        }
    }
}
