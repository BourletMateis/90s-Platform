using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class OptionSettings : MonoBehaviour
{

    public TMP_Dropdown ResDropDown;
    public Toggle FullScreenToggle;

    Resolution[] AllResolutions;
    bool IsFullScreen;
    int SelectdResolution;
    List<Resolution> SelectedResolutionList = new List<Resolution>();

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

