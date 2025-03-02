using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleLabelDisplayer : MonoBehaviour
{
    private Toggle _settingToggle;
    private TextMeshProUGUI _label;

    private void Awake()
    {
        _settingToggle = GetComponent<Toggle>();
        _label = _settingToggle.transform.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        _settingToggle.onValueChanged.AddListener(SetLabel);
    }

    private void SetLabel(bool isOn)
    {
        _label.text = isOn ? "ON" : "OFF";
    }
}
