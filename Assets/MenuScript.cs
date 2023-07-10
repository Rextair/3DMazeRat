using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public GameObject MainMenuGameObject;
    public GameObject StartMenuGameObject;
    public GameObject SettingsMenuGameObject;
    public GameObject ManualGameObject;

    public Object LoadLevel1;
    public Object LoadLevel2;
    public Object LoadLevel3;
    public Object LoadLevel4;
    public Object LoadLevel5;

    public AudioSource AudioClick;
    public AudioSource AudioHover;

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

        else if (MenuNumber == 1)
        {
            ShowStartMenu();
        }

        else if(MenuNumber == 2)
        {
            ShowSettingsMenu();
        }

        else if (MenuNumber == 3)
        {
            ShowManualMenu();
        }
    }

    //Show menu widgets

    public void ShowMainMenu()
    {
        MainMenuGameObject.SetActive(true);
        StartMenuGameObject.SetActive(false);
        SettingsMenuGameObject.SetActive(false);
        ManualGameObject.SetActive(false);
    }

    public void ShowStartMenu()
    {
        MainMenuGameObject.SetActive(false);
        StartMenuGameObject.SetActive(true);
        SettingsMenuGameObject.SetActive(false);
    }

    public void ShowSettingsMenu()
    {
        MainMenuGameObject.SetActive(false);
        StartMenuGameObject.SetActive(false);
        SettingsMenuGameObject.SetActive(true);
    }

    public void ShowManualMenu()
    {
        MainMenuGameObject.SetActive(false);
        StartMenuGameObject.SetActive(false);
        ManualGameObject.SetActive(true);
        SettingsMenuGameObject.SetActive(false);
    }

    // On button clicks

    public void OnQuitButton()
    {
        if(MenuNumber == 0)
        {
            Application.Quit();
        }
    }

    public void OnSettingsButton()
    {
        if(MenuNumber == 0)
        {
            MenuNumber = 2;
            AudioClick.Play();
        }
    }

    public void OnStartButton()
    {
        if(MenuNumber == 0)
        {
            MenuNumber = 3;
            AudioClick.Play();
        }
    }

    public void OnBackButton()
    {
        if(MenuNumber != 0)
        {
            MenuNumber = 0;
            AudioClick.Play();
        }
    }

    //Go to level

    public void ButtonLevel1()
    {
        if (MenuNumber == 3)
        {
            SceneManager.LoadScene("level1");
            AudioClick.Play();
        }
    }

    public void ButtonLevel2()
    {
        if (MenuNumber == 1)
        {
            SceneManager.LoadScene(LoadLevel2.name);
            AudioClick.Play();
        }
    }

    public void ButtonLevel3()
    {
        if (MenuNumber == 3)
        {
            SceneManager.LoadScene(LoadLevel3.name);
            AudioClick.Play();
        }
    }

    public void ButtonLevel4()
    {
        if (MenuNumber == 4)
        {
            SceneManager.LoadScene(LoadLevel4.name);
            AudioClick.Play();
        }
    }

    public void ButtonLevel5()
    {
        if (MenuNumber == 5)
        {
            SceneManager.LoadScene(LoadLevel5.name);
            AudioClick.Play();
        }
    }
}
