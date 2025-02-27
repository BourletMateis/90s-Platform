using UnityEngine;
using UnityEngine.SceneManagement; // Pour changer de scène

public class CharacterCarousel : MonoBehaviour
{
    public GameObject[] characters; // Tes personnages
    public int currentIndex = 0; // L'index du perso sélectionné

    void Start()
    {
        Debug.Log("Début du script, nombre de personnages : " + characters.Length);

        if (characters == null || characters.Length == 0)
        {
            Debug.LogError("Le tableau characters est vide !");
            return;
        }

        currentIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        if (currentIndex < 0 || currentIndex >= characters.Length)
        {
            Debug.LogWarning("Index sauvegardé invalide, réinitialisation à 0.");
            currentIndex = 0;
        }

        ShowCharacter(currentIndex);
    }


    public void ShowNextCharacter()
    {
        characters[currentIndex].SetActive(false);
        currentIndex = (currentIndex + 1) % characters.Length;
        ShowCharacter(currentIndex);
    }

    public void ShowPreviousCharacter()
    {
        characters[currentIndex].SetActive(false);
        currentIndex = (currentIndex - 1 + characters.Length) % characters.Length;
        ShowCharacter(currentIndex);
    }

    void ShowCharacter(int index)
    {
        characters[index].SetActive(true);
    }

    public void OnPlayButtonClicked()
    {
        PlayerPrefs.SetInt("SelectedCharacter", currentIndex);
        PlayerPrefs.Save(); 
        SceneManager.LoadScene("Level_1"); 
    }
}
