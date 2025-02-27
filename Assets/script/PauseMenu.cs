using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; 
    private bool isPaused = false; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused)
            {
                Resume(); 
            }
            else
            {
                Pause(); 
            }
        }
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f; 
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false;
    }

    public void restart()
    {
        Debug.Log("Je charge");
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1f;
    }
    
    public void returnMenu()
    {
        pauseMenuUI.SetActive(true);
    }

}
