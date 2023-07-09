using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float countdownTime = 30f; 
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI vaseCounterText;

    RatController ratController;

    private float currentTime; 
    private void Start()
    {
        currentTime = countdownTime;
        ratController = FindObjectOfType<RatController>();
    }

    private void Update()
    {
       //Timer
        currentTime -= Time.deltaTime;

       
        if (currentTime < 0f)
        {
            currentTime = 0f;
            if(GameManager.instance.isGameRunning)
            {
                GameManager.instance.IsBotDetained = true;
            }
        }

       
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

       
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        //Vase
       // VaseCounterText.text = rC.currentSpawnCount.ToString();
        vaseCounterText.text = ratController.reverseSpawnCount.ToString();
    }
}

