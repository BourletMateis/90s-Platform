using UnityEngine;
using UnityEngine.UI;

public class OptionSettings : MonoBehaviour
{
    Resolution[] resolution;
    public Dropdown resolutiondrop; // <-- V�rifie que c'est bien un Dropdown

    public void Start()
    {
        resolution = Screen.resolutions;

        if (resolutiondrop == null)
        {
            Debug.LogError("Le Dropdown de r�solution n'est pas assign� dans l'inspecteur !");
            return;
        }

        resolutiondrop.ClearOptions();
    }
}

