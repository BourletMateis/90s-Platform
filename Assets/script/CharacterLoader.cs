using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public GameObject[] characters;
    public Transform spawnPoint;
    void Start()
    {
        if (spawnPoint == null)
        {
            Debug.LogError("?? spawnPoint n'est pas assigné ! Assignes-en un dans l'Inspector.");
            return;
        }

        int selectedIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Instantiate(characters[selectedIndex], spawnPoint.position, Quaternion.identity);
    }
}
