using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject settingsWindow;

    public GameObject firstSelectedButton, firstSettingSelectedButton, optionClosedButton;

    private void Start()
    {
        //we have to remove the first selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set the new selected object
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSettingSelectedButton);
    }
    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionClosedButton);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
    
    public void OnClickSound()
    {
        Application.Quit();
    }
}
