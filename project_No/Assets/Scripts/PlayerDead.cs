using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
    public string stageName;
    public string reTryStage;

    public Button startButton;
    public Button reTryButton;
    public Button endButton;
    private void Start()
    {
        startButton = GetComponent<Button>();
        reTryButton = GetComponent<Button>();
        endButton = GetComponent<Button>();
    }

    private void Awake()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(SceneLoad);
        }

        if (reTryButton != null)
        {
            reTryButton.onClick.AddListener(ReSceneLoad);
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

    private void ReSceneLoad()
    {
        LoadingScene.LoadScene(reTryStage);
    }

    private void GameQuit()
    {
        Application.Quit();
    }
}
