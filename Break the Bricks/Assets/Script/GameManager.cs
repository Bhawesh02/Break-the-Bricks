using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public List<BrickController> Bricks;

    public PlayerController playerController;

    [SerializeField]
    private GameObject LevelCompleteScreen;

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
        LevelCompleteScreen.SetActive(false);
    }
    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    private void Update()
    {
        if (Bricks.Count == 0)
            LevelCompleted();
    }

    private void LevelCompleted()
    {
        GameOver = true;
        playerController.enabled = false;
        LevelCompleteScreen.SetActive(true);
    }
}
