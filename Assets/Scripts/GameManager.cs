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
    }

    public void BotWins()
    {
        Debug.Log("Player wins!");
        isGameRunning = false;
    }
}

