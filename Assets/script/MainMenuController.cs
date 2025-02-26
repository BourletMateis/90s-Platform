using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
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

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }
}
