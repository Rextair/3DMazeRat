using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject bot; 
    public GameObject mouse; 
    public Transform finish;
    public bool isGameRunning = true; 
    public bool IsBotAtFinish = false;
    public bool IsBotDetained = false;
    [SerializeField] Canvas mouseWinsCanvas;
    [SerializeField] Canvas botWinsCanvas;
    private void Awake() {
        instance = this;
    }

    private void Update()
    {
        if (isGameRunning)
        {
            if (IsBotAtFinish)
            {
                BotWins();
            }
            else if (IsBotDetained)
            {
                MouseWins();
            }
        }
    }
    public void MouseWins()
    { 
        Debug.Log("Mouse wins!");
        isGameRunning = false; 
        Time.timeScale = 0f;
        FindObjectOfType<RatController>().enabled = false;
        GetComponent<Timer>().timerText.enabled = false;
        mouseWinsCanvas.enabled = true;
    }

    public void BotWins()
    {
        Debug.Log("Player wins!");
        isGameRunning = false;
        Time.timeScale = 0f;
        FindObjectOfType<RatController>().enabled = false;
        GetComponent<Timer>().timerText.enabled = false;
        botWinsCanvas.enabled = true;
    }
}

