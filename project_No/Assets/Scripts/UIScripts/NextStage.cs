using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public string stageName;

    FadeInOut fadeInOut;
    
    private void Start()
    {
        fadeInOut = FindObjectOfType<FadeInOut>();

        fadeInOut.OnFadeOut = SceneLoad;
    }

    private void OnTriggerEnter(Collider other)
    {
        fadeInOut.StartFadeOut();
    }

    private void SceneLoad()
    {
        SceneManager.LoadScene(stageName);        
    }
}
