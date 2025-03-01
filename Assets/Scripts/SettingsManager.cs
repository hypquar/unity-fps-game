using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    public static SettingsManager Instance { get; private set; }

    [SerializeField] private SettingsData _settingsData;

    private DataManager _dataManager;

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
    }

    void Start()
    {
        _dataManager = DataManager.Instance;
    }

    void Update()
    {
        
    }

    internal void SetResolution(string resolutionString)
    {
        _settingsData.resolution = resolutionString;

        string[] resolutionParams = resolutionString.Split('x');

        int width = int.Parse(resolutionParams[0]);
        int height = int.Parse(resolutionParams[1]);

        Screen.SetResolution(width, height, !_settingsData.isWindowed);
    }

    internal void ToggleWindowedMode(bool isWindowed)
    {
        _settingsData.isWindowed = isWindowed;

        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, _settingsData.isWindowed);
    }

    internal void ToggleSound(bool isSoundEnabled)
    {
        _settingsData.isSoundEnabled = isSoundEnabled;


    }

    internal void SetVolumeValue(float value)
    {
        throw new NotImplementedException();
    }
}
