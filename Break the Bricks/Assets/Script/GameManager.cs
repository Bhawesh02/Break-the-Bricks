using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public List<BrickController> Bricks;

    public PlayerController playerController;

    [SerializeField]
    private GameObject LevelCompleteScreen;

    public bool GameLost;

    public bool LevelComplete;

    public int NumOfBallsInScene;

    public GameObject gameOverGameObject;

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
        GameLost = false;
        LevelComplete = false;
        NumOfBallsInScene = 0;
        PlayerPrefs.SetInt("LastLevel",SceneManager.GetActiveScene().buildIndex);
    }
    private void Start()
    {

        LevelCompleteScreen.SetActive(false);
        gameOverGameObject.SetActive(false);


        Screen.SetResolution(1920, 1080, true);
    }
    private void Update()
    {
        if (Bricks.Count == 0)
            LevelCompleted();
        if(playerController.NumOfBallsAvailable == 0 && NumOfBallsInScene == 0 && !LevelComplete)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        GameLost = true;
        playerController.enabled = false;
        gameOverGameObject.SetActive(true);
    }

    private void LevelCompleted()
    {
        LevelComplete = true;
        playerController.enabled = false;
        LevelCompleteScreen.SetActive(true);
    }
}
