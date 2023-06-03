
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private ButtonType type;
    private Button button;
    public int LevelToLoad;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    private void Start()
    {
        button.onClick.AddListener(ChangeLevel);
        if (type == ButtonType.Continue && (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings))
            Destroy(gameObject);
    }

    private void ChangeLevel()
    {
        switch (type)
        {
            case ButtonType.Replay:
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case ButtonType.Next:
                int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(CurrentSceneIndex + 1);
                break;
            case ButtonType.LoadLevel:
                    SceneManager.LoadScene(LevelToLoad);
                break;
            default:
                break;
        }
    }

}
