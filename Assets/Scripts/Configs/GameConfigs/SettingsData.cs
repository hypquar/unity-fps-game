using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Settings Data", menuName = "Data/Settings Data")]
public class SettingsData : ScriptableObject
{
    public string resolution;
    public bool isWindowed;
    public bool isSoundEnabled;
    public float volumeValue;

    internal void LoadFromJson(string json)
    {
        JsonUtility.FromJson<SettingsData>(json);
    }

    internal string SaveToJsonString()
    {
        return JsonUtility.ToJson(this, true);
    }
}
