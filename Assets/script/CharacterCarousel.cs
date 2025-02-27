using UnityEngine;

public class CharacterCarousel : MonoBehaviour
{
    public GameObject[] characters;
    public int currentIndex = 0;

    void Start()
    {
        if (characters == null || characters.Length == 0)
        {
            Debug.LogError("Le tableau characters est vide !");
            return;
        }

        // Correction si currentIndex est hors limites
        if (currentIndex < 0 || currentIndex >= characters.Length)
        {
            Debug.LogWarning("currentIndex hors limites, réinitialisation à 0.");
            currentIndex = 0;
        }

        ShowCharacter(currentIndex);
    }

    public void ShowNextCharacter()
    {
        if (characters == null || characters.Length == 0) return;

        characters[currentIndex]?.SetActive(false);
        currentIndex = (currentIndex + 1) % characters.Length;
        ShowCharacter(currentIndex);
    }

    public void ShowPreviousCharacter()
    {
        if (characters == null || characters.Length == 0) return;

        characters[currentIndex]?.SetActive(false);
        currentIndex = (currentIndex - 1 + characters.Length) % characters.Length;
        ShowCharacter(currentIndex);
    }

    void ShowCharacter(int index)
    {
        if (characters == null || characters.Length == 0) return;

        if (index < 0 || index >= characters.Length)
        {
            Debug.LogError("Index hors limites dans ShowCharacter: " + index);
            return;
        }

        if (characters[index] != null)
        {
            characters[index].SetActive(true);
        }
        else
        {
            Debug.LogError("Personnage null à l'index : " + index);
        }
    }
}
