﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider soundSlider;

    public Toggle fullscreenToggl;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Awake()
    {
        //Load fullscreen
        int isFullscreen = PlayerPrefs.GetInt("Fullscreen");

        if (isFullscreen == 1)
        {
            SetFullScreen(true);
            fullscreenToggl.isOn = true;
        }
        else
        {
            SetFullScreen(false);
            fullscreenToggl.isOn = false;
        }

        //load resolution
        resolutionDropdown.onValueChanged.AddListener(new UnityAction<int>(indexer =>
        {
            PlayerPrefs.SetInt("Resolution", resolutionDropdown.value);
            PlayerPrefs.Save();
        }));
        
    }

    public void Start()
    {
        float masterVolume = PlayerPrefs.GetFloat("VolumeMaster", 0);
        masterSlider.value = masterVolume;
        audioMixer.SetFloat("VolumeMaster", masterVolume);
        float musicVolume = PlayerPrefs.GetFloat("VolumeMusic", 0);
        musicSlider.value = musicVolume;
        audioMixer.SetFloat("VolumeMusic", musicVolume);
        float soundVolume = PlayerPrefs.GetFloat("VolumeSound", 0);
        soundSlider.value = soundVolume;
        audioMixer.SetFloat("VolumeSound", soundVolume);

        //get the resolution of the screen
        resolutions = Screen.resolutions.Select(Resolution => new Resolution { width = Resolution.width, height = Resolution.height }).Distinct().ToArray(); //avoid duplication into the resoluion array
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution", currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();
    }


    public void SetMasterVolume(float volume)
    {
        PlayerPrefs.SetFloat("VolumeMaster", volume);
        audioMixer.SetFloat("VolumeMaster", volume);
    }
    public void SetSoundVolume(float volume)
    {
        PlayerPrefs.SetFloat("VolumeSound", volume);
        audioMixer.SetFloat("VolumeSound", volume);
    }
    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("VolumeMusic", volume);
        audioMixer.SetFloat("VolumeMusic", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        if (isFullScreen)
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Fullscreen", 0);
        }
    }


    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ClearSavedData()
    {
        PlayerPrefs.DeleteAll();
    }
}
