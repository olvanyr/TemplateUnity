using UnityEngine;

public class LoadAndSaveSettings : MonoBehaviour
{
    public static LoadAndSaveSettings instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of LoadAndSaveSettings in the scene");
            return;
        }
        instance = this;
    }


    public SettingsMenu settingsMenu;

    public void SaveSetting()
    {
        settingsMenu.audioMixer.GetFloat("VolumeMaster", out float masterVolume); //getFloat give a bool so with out float, we get the real value, not the information of if the mixer existe
        settingsMenu.audioMixer.GetFloat("VolumeMusic", out float musicVolume);
        settingsMenu.audioMixer.GetFloat("VolumeSound", out float soundVolume);

        PlayerPrefs.SetFloat("VolumeMaster", masterVolume);
        PlayerPrefs.SetFloat("VolumeMusic", musicVolume);
        PlayerPrefs.SetFloat("VolumeSound", soundVolume);

        Debug.Log("settings Saved");
        Debug.Log("VolumeMaster" + masterVolume);

    }

    public void LoadSetting()
    {
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0f);
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0f);
        float soundVolume = PlayerPrefs.GetFloat("SoundVolume", 0f);

        settingsMenu.audioMixer.SetFloat("VolumeMaster", masterVolume);
        settingsMenu.audioMixer.SetFloat("VolumeSound", musicVolume);
        settingsMenu.audioMixer.SetFloat("VolumeMusic", soundVolume);
        settingsMenu.masterSlider.value = masterVolume;
        settingsMenu.musicSlider.value = musicVolume;
        settingsMenu.soundSlider.value = soundVolume;

        Debug.Log("settings Loaded");
    }
}
