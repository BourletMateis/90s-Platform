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
        MenuUI.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SpikeScript spike = GetComponent<SpikeScript>();

            if (spike != null)
            {
                if (spike.IsSpikeUp())
                {
                    Time.timeScale = 0f;
                    ShowDeathMenu();
                }
                else
                {
                }
            }
            else
            {
                Debug.LogError("Aucun SpikeScript trouvé !");
            }
        }
    }

}
