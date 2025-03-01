using UnityEngine;

[CreateAssetMenu(fileName = "Settings Data", menuName = "Data/Settings Data")]
public class SettingsData : ScriptableObject
{
    public string resolution;
    public bool isWindowed;
    public bool isSoundEnabled;
    public float volumeValue;
}
