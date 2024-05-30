using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour
{
    public Dropdown resolutionDropdown;

    private List<Resolution> availableResolutions;

    void Start()
    {
        availableResolutions = new List<Resolution>
        {
                new Resolution { width = 2560, height = 1440 },
                new Resolution { width = 1920, height = 1080 },
                new Resolution { width = 1366, height = 768  }
        };

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (Resolution resolution in availableResolutions)
        {
            string option = resolution.width + " x " + resolution.height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(resolutionDropdown.value); });

        // Устанавливаем текущее разрешение как выбранное по умолчанию
        Resolution currentResolution = Screen.currentResolution;
        for (int i = 0; i < availableResolutions.Count; i++)
        {
            if (availableResolutions[i].width == currentResolution.width &&
                availableResolutions[i].height == currentResolution.height)
            {
                resolutionDropdown.value = i;
                break;
            }
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = availableResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
