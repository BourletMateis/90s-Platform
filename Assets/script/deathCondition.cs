using UnityEngine;

public class deathCondition : MonoBehaviour
{
    public GameObject MenuUI;

    void Start()
    {
        MenuUI.SetActive(false);
    }

    void Update()
    {
    }

    public void ShowDeathMenu()
    {
        Time.timeScale = 0f;
        MenuUI.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            MenuUI.SetActive(true);
        }
    }
}
