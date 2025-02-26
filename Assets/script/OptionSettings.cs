using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class OptionSettings : MonoBehaviour
{

    public TMP_Dropdown ResDropDown;
    public Toggle FullScreenToggle;
    public AudioMixer audioMixer;

    Resolution[] AllResolutions;
    bool IsFullScreen;
    int SelectdResolution;
    List<Resolution> SelectedResolutionList = new List<Resolution>();

    [SerializeField]
    private AudioMixer Mixer;
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]    
    private TextMeshProUGUI ValueText;

    public void Start()
    {
        IsFullScreen = true;
        AllResolutions = Screen.resolutions;


        List<string> resolutionStringList = new List<string>();
        string newRes;
        foreach (Resolution res in AllResolutions)
        {
            newRes = res.width.ToString() + " x " + res.height.ToString();
            if (!resolutionStringList.Contains(newRes))
            {
                resolutionStringList.Add(res.ToString());
                SelectedResolutionList.Add(res);
            }
        }

        ResDropDown.AddOptions(resolutionStringList);
    }

    public void OnChangeSlider(float Value)
    {
        ValueText.SetText($"{Value.ToString("N4")}");
        Mixer.SetFloat("Volume", (-80 + Value * 100));

    }


    public void ChangeResolution()
    {
        SelectdResolution = ResDropDown.value;
        Screen.SetResolution(SelectedResolutionList[SelectdResolution].width, SelectedResolutionList[SelectdResolution].height, IsFullScreen);
    }

    public void ChangeFullScreen()
    {
        IsFullScreen = FullScreenToggle.isOn;
        Screen.SetResolution(SelectedResolutionList[SelectdResolution].width, SelectedResolutionList[SelectdResolution].height, IsFullScreen);

    }

}

