using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public GameObject MainMenuGameObject;
    public GameObject SettingsMenuGameObject;

    public float MenuNumber; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MenuNumber == 0)
        {
            ShowMainMenu();
        }
        else if(MenuNumber == 1)
        {
            ShowSettingsMenu();
        }
    }

    public void ShowMainMenu()
    {
        MainMenuGameObject.SetActive(true);
        SettingsMenuGameObject.SetActive(false);
    }

    public void ShowSettingsMenu()
    {
        MainMenuGameObject.SetActive(false);
        SettingsMenuGameObject.SetActive(true);
    }

    // On button clicks

    public void OnSettingsButton()
    {
        if(MenuNumber == 0)
        {
            MenuNumber = 1;
        }
    }

    public void OnStartButton()
    {
        if(MenuNumber == 0)
        {
            MenuNumber = 0;
        }
    }

    public void OnBackButton()
    {
        if(MenuNumber != 0)
        {
            MenuNumber = 0;
        }
    }
}
