using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterCarousel : MonoBehaviour
{
    public GameObject[] characters; 
    public int currentIndex = 0; 

    void Start()
    {
        Debug.Log("D�but du script, nombre de personnages : " + characters.Length);

        if (characters == null || characters.Length == 0)
        {
            Debug.LogError("Le tableau characters est vide !");
            return;
        }

        currentIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        if (currentIndex < 0 || currentIndex >= characters.Length)
        {
            Debug.LogWarning("Index sauvegard� invalide, r�initialisation � 0.");
            currentIndex = 0;
        }

        ShowCharacter(currentIndex);
    }


    public void ShowNextCharacter()
    {
        characters[currentIndex].SetActive(false);
        currentIndex = (currentIndex + 1) % characters.Length;

        PlayerPrefs.SetInt("SelectedCharacter", currentIndex);
        PlayerPrefs.Save(); 

        Debug.Log("Personnage s�lectionn� et sauvegard� (next) : " + currentIndex);

        ShowCharacter(currentIndex);
    }

    public void ShowPreviousCharacter()
    {
        characters[currentIndex].SetActive(false);
        currentIndex = (currentIndex - 1 + characters.Length) % characters.Length;

        PlayerPrefs.SetInt("SelectedCharacter", currentIndex);
        PlayerPrefs.Save(); 

        Debug.Log("Personnage s�lectionn� et sauvegard� (previous) : " + currentIndex);

        ShowCharacter(currentIndex);
    }

    void ShowCharacter(int index)
    {
        characters[index].SetActive(true);
    }

    public void OnPlayButtonClicked()
    {
        currentIndex = PlayerPrefs.GetInt("SelectedCharacter", 0); 

        Debug.Log("Sauvegarde avant changement de sc�ne : " + currentIndex);

        PlayerPrefs.SetInt("SelectedCharacter", currentIndex);
        PlayerPrefs.Save();

        Debug.Log("Index sauvegard� avant changement de sc�ne : " + PlayerPrefs.GetInt("SelectedCharacter"));

        SceneManager.LoadScene("Level_1");
    }
}
