using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void PlayScene(string sceneName)
    {
        SceneManager.LoadScene("Level_1");
    }

    public void SettingScene(string sceneName)
    {
        SceneManager.LoadScene("settingMenu");
    }

    public void returnhome(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("gameMenu");
    }

    public void playgame(string sceneName)
    {
        SceneManager.LoadScene("homePlayer");
    }

    public void Startgame(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_1");

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
