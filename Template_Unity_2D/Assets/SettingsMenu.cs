using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider soundSlider;


    public AudioMixer audioMixer;

    public Dropdown resoltuionDropdown;

    Resolution[] resolutions;


    public void Start()
    {
        //get the value of all the mixer and aplie them to the slider 
        audioMixer.GetFloat("VolumeMaster", out float masterValueForSlider); //getFloat give a bool so with out float, we get the real value, not the information of if the mixer existe
        masterSlider.value = masterValueForSlider;
        audioMixer.GetFloat("VolumeMusic", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;
        audioMixer.GetFloat("VolumeSound", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;

        //get the resolution of the screen
        resolutions = Screen.resolutions.Select(Resolution => new Resolution { width = Resolution.width, height = Resolution.height }).Distinct().ToArray(); //avoid duplication into the resoluion array
        resoltuionDropdown.ClearOptions();

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

        resoltuionDropdown.AddOptions(options);
        resoltuionDropdown.value = currentResolutionIndex;
        resoltuionDropdown.RefreshShownValue();

        Screen.fullScreen = true;

    }


    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("VolumeMaster", volume);
    }
    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("VolumeSound", volume);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("VolumeMusic", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
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
