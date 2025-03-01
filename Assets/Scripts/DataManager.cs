using System;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; set; }

    public string configPath;
    public string unitConfigPath;
    public string gameConfigPath;

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
    private void Start()
    {
        configPath = Path.Combine(Application.dataPath, "Config");
        Directory.CreateDirectory(configPath);

        unitConfigPath = Path.Combine(configPath, "Units");
        Directory.CreateDirectory(unitConfigPath);
    }

    /*
    private void LoadSettings()
    {
        foreach (UnitData unitData in _unitDataList)
        {
            string filePath = Path.Combine(unitConfigPath, unitData.name + ".json");

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                unitData.LoadFromJson(json);
                Debug.Log($"Загружен юнит: {unitData.unitName}");
            }
            else
            {
                Debug.LogError($"Файл {filePath} не найден!");
            }
        }
    }

    private void SaveSettings()
    {
        foreach (UnitData unitData in _unitDataList)
        {
            string filePath = Path.Combine(unitConfigPath, unitData.name + ".json");

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                unitData.LoadFromJson(json);
                Debug.Log($"Загружен юнит: {unitData.unitName}");
            }
            else
            {
                Debug.LogError($"Файл {filePath} не найден!");
            }
        }
    } */
}
