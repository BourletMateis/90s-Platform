using UnityEngine;
using UnityEngine.UI;

public class OptionSettings : MonoBehaviour
{
    Resolution[] resolution;
    public Dropdown resolutiondrop; // <-- Vérifie que c'est bien un Dropdown

    public void Start()
    {
        resolution = Screen.resolutions;

        if (resolutiondrop == null)
        {
            Debug.LogError("Le Dropdown de résolution n'est pas assigné dans l'inspecteur !");
            return;
        }

        resolutiondrop.ClearOptions();
    }
}

