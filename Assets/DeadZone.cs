using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameObject WinMenuUI;

    void Start()
    {
        WinMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowDeathMenu()
    {
        Time.timeScale = 0f;
        WinMenuUI.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            WinMenuUI.SetActive(true);
        }
    }
}