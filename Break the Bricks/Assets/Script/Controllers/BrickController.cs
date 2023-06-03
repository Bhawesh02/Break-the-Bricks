
using TMPro;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private TextMeshPro healthText;
    private void Awake()
    {
        health = Random.Range(1,50);
    }
    private void Start()
    {
        healthText.text = "" + health;
        GameManager.Instance.Bricks.Add(this);
    }
    private void ReduceHealth()
    {
        health--;
        if (health == 0)
        {
            Destroy(gameObject);
            return;
        }
        healthText.text = ""+health;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BallController>() == null)
            return;
        
        ReduceHealth();
    }
    private void OnDestroy()
    {
        GameManager.Instance.Bricks.Remove(this);
    }
}
