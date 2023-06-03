using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button ContinueButton, SelectLevelButton, QuitButton;
    [SerializeField]
    private GameObject SelectLevelUI;
    [SerializeField]
    private GameObject LevelLockedUI;
    public int LastLevel;

    [SerializeField]
    private List<Button> GoToLevelButtons;

    private void Awake()
    {
        LastLevel = PlayerPrefs.GetInt("LastLevel", 1);
    }

    private void SelectLevel()
    {
        SelectLevelUI.SetActive(true);
    }

    private void Start()
    {

        SelectLevelButton.onClick.AddListener(SelectLevel);
        QuitButton.onClick.AddListener(QuitGame);
        SelectLevelUI.SetActive(false);
        LevelLockedUI.SetActive(false);


        if (LastLevel == 1)
        {
            ContinueButton.GetComponentInChildren<TextMeshProUGUI>().text = "Start";
            ContinueButton.GetComponent<LoadLevel>().LevelToLoad = 1;
            
        }
        ContinueButton.GetComponent<LoadLevel>().LevelToLoad = LastLevel;
        foreach (Button button in GoToLevelButtons)
        {
            LoadLevel loadLevel = button.GetComponent<LoadLevel>();
            if(loadLevel.LevelToLoad > LastLevel)
            {
                Destroy(loadLevel);
                button.onClick.AddListener(ShowLevelLocked);
            }
        }
    }

    private void ShowLevelLocked()
    {
        LevelLockedUI.SetActive(true);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
