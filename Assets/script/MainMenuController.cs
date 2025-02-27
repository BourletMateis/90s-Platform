using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void PlayScene(string sceneName)
    {
        SceneManager.LoadScene("clementscene");
    }

    public void SettingScene(string sceneName)
    {
        SceneManager.LoadScene("settingMenu");
    }

    public void returnhome(string sceneName)
    {
        SceneManager.LoadScene("gameMenu");
    }

    public void playgame(string sceneName)
    {
        SceneManager.LoadScene("homePlayer");
    }

    public void Startgame(string sceneName)
    {
        SceneManager.LoadScene("clementscene");
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
