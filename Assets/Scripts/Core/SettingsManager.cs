using System;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{

    public static SettingsManager Instance { get; private set; }

    public SettingsData settingsData;

    private DataManager _dataManager;
    private SoundManager _soundManager;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }


        _dataManager = DataManager.Instance;
        _soundManager = SoundManager.Instance;
    }

    private void Start()
    {
        ApplySettings();
    }

    public void ApplySettings()
    {
        
    }

    internal void SetResolution(string resolutionString)
    {
        settingsData.resolution = resolutionString;

        string[] resolutionParams = resolutionString.Split('x');

        int width = int.Parse(resolutionParams[0]);
        int height = int.Parse(resolutionParams[1]);

        foreach (Resolution resolution in Screen.resolutions)
        {
            if (resolution.width == width && resolution.height == height)
            {
                Screen.SetResolution(width, height, !settingsData.isWindowed);
            }
        }
    }

    internal void ToggleWindowedMode(bool isWindowed)
    {
        settingsData.isWindowed = isWindowed;

        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, settingsData.isWindowed);
    }

    internal void ToggleSound(bool isSoundEnabled)
    {
        settingsData.isSoundEnabled = isSoundEnabled;

        _soundManager.audioSource.mute = !isSoundEnabled;
    }

    internal void SetVolumeValue(float value)
    {
        settingsData.volumeValue = value;

        _soundManager.audioSource.volume = value;
    }
}
