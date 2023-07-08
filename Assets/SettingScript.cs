using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SettingScript : MonoBehaviour
{
    public TMP_Dropdown FullscreenDropdown;
    public Slider VolumeValue;
    public Slider SensetivityValue;

    public AudioMixer audioMixer;
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

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("GlobalVolume", volume);

    }

    public void SetSensevity(float sense)
    {

    }

    public void saveSettings()
    {
        float SavedFullScreen = FullscreenDropdown.value;
        float SavedVolume = VolumeValue.value;
        float SavedSensetivity = SensetivityValue.value;

        PlayerPrefs.SetFloat("FullscreenValue", FullscreenDropdown.value);
        PlayerPrefs.SetFloat("VolumeValue", VolumeValue.value);
        PlayerPrefs.SetFloat("SensetivityValue", SensetivityValue.value);

        loadValues();
    }

    public void loadValues()
    {
        //float 
    }

    public void resetSettings()
    {
        FullscreenDropdown.value = 0;
        SetVolume(0);
        SetSensevity(0);

    }
}
