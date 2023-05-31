using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public List<BrickController> Bricks;

    public bool GameOver = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    private void Update()
    {
        if (Bricks.Count == 0)
            GameOver = true;
    }

}
