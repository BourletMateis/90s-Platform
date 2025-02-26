using UnityEngine;

public class CharacterCarousel : MonoBehaviour
{
    public GameObject[] characters;  
    public int currentIndex = 0;

    void Start()
    {
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
}
