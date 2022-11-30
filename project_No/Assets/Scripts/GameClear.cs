using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public string stageName;

    public Button startButton;
    public Button endButton;
    private void Start()
    {
        startButton = GetComponent<Button>();
        endButton = GetComponent<Button>();
    }

    private void Awake()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(SceneLoad);
        }

        if (startButton != null)
        {
            endButton.onClick.AddListener(GameQuit);
        }
    }

    private void SceneLoad()
    {
        LoadingScene.LoadScene(stageName);
    }

    private void GameQuit()
    {
        Application.Quit();
    }
}
