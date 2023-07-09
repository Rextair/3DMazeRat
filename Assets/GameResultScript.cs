using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResultScript : MonoBehaviour
{

    public AudioSource PlayAudio;
    public Object MainMenuScene;
    public Object RetryScene;
    public Object NextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRetry()
    {
        SceneManager.LoadScene(RetryScene.name);
        Time.timeScale = 1f;
    }

    public void OnMenu()
    {
        SceneManager.LoadScene(MainMenuScene.name);
        Time.timeScale = 1f;
    }

    public void OnNextLevel()
    {
        SceneManager.LoadScene(NextScene.name);
        Time.timeScale = 1f;
    }

}
