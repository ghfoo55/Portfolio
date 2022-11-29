using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Player player;
    Enemy enemy;

    public Player MainPlayer
    {
        get => player;
    }

    public Enemy enemyMonster
    {
        get => enemy;
    }

    static GameManager instance = null;
    public static GameManager Inst { get => instance; }

    int sceneIndex = 0; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            instance.Initialize();
            DontDestroyOnLoad(this.gameObject);            
        }
        else 
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        

        if (sceneIndex != arg0.buildIndex)
        {
            sceneIndex = arg0.buildIndex;
        }
    }

    private void Initialize()
    {
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
}
