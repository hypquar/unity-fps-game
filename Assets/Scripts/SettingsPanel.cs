using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private Toggle _windowedToggle;
    [SerializeField] private Toggle _soundsToggle;
    [SerializeField] private Slider _volumeSlider;

    private SettingsManager _settingsManager;


    void Start()
    {


        _settingsManager = SettingsManager.Instance;

        _resolutionDropdown.onValueChanged.AddListener(GetResolutionOption);

        _windowedToggle.onValueChanged.AddListener(_settingsManager.ToggleWindowedMode);
        _soundsToggle.onValueChanged.AddListener(_settingsManager.ToggleSound);
        _volumeSlider.onValueChanged.AddListener(_settingsManager.SetVolumeValue);
    }

    private void GetResolutionOption(int index)
    {
        string resolutionString = _resolutionDropdown.options[index].text;

        _settingsManager.SetResolution(resolutionString);
    }
}
