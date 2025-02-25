using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolution;
    public Dropdown resolutiondrop;

    public void Start()
    {
        resolution = Screen.resolutions;
        resolutiondrop.ClearOptions();
    }

    public void PlayScene(string sceneName)
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingScene(string sceneName)
    {
        SceneManager.LoadScene("settingMenu");
    }

    public void returnhome(string sceneName)
    {
        SceneManager.LoadScene("gameMenu");
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }
}
