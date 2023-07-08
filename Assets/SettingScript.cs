using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingScript : MonoBehaviour
{
    public TMP_Dropdown FullscreenDropdown;
    public Slider VolumeValue;
    public Slider SensetivityValue;
    // Start is called before the first frame update
    void Start()
    {
        FullscreenDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDropdownValueChanged(int optionIndex)
    {
        if(optionIndex == 2)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }

        else if(optionIndex == 1)
        {
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        }

        else if(optionIndex == 0)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }

    }
}
