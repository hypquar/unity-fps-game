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

    private void Awake()
    {
        _settingsManager = SettingsManager.Instance;
    }    
    
    void Start()
    {
        for (int index = 0; index < _resolutionDropdown.options.Count; index++)
        {
            if (_settingsManager.settingsData.resolution.Equals(_resolutionDropdown.options[index]))
            {
                _resolutionDropdown.value = index;
            }
        }

        _volumeSlider.value = _settingsManager.settingsData.volumeValue;

        _resolutionDropdown.onValueChanged.AddListener(GetResolutionOption);
        _windowedToggle.onValueChanged.AddListener(_settingsManager.ToggleWindowedMode);
        _soundsToggle.onValueChanged.AddListener(_settingsManager.ToggleSound);
        _volumeSlider.onValueChanged.AddListener(_settingsManager.SetVolumeValue);
    }

    public void ExitSettings()
    {

    }

    private void GetResolutionOption(int index)
    {
        string resolutionString = _resolutionDropdown.options[index].text;

        _settingsManager.SetResolution(resolutionString);
    }
}
