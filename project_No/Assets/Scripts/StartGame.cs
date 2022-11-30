using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public string stageName;

    FadeInOut fadeInOut;

    public Button startButton;
    public Button endButton;
    private void Start()
    {
        fadeInOut = FindObjectOfType<FadeInOut>();       
        startButton = GetComponent<Button>();
        endButton = GetComponent<Button>();
        fadeInOut.OnFadeOut = SceneLoad;
    }

    private void Awake()
    {        
        if(startButton != null)
        {
            startButton.onClick.AddListener(SceneLoad);            
        }
        
        if(endButton != null)
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
