using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; set; }

    public SettingsData settingsData;

    private string configPath;
    private string unitConfigPath;
    private string gameConfigPath;

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
        configPath = Path.Combine(Application.streamingAssetsPath, "Config");

        if (!Directory.Exists(configPath))
        {
            Directory.CreateDirectory(configPath);
        }

        unitConfigPath = Path.Combine(configPath, "Units");

        if (!Directory.Exists(unitConfigPath))
        {
            Directory.CreateDirectory(unitConfigPath);
        }

        gameConfigPath = Path.Combine(configPath, "Game");

        if (!Directory.Exists(gameConfigPath))
        {
            Directory.CreateDirectory(unitConfigPath);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveSettings();
        }
    }
    private void LoadSettings()
    {
        string filePath = Path.Combine(gameConfigPath, "settings_config.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            settingsData.LoadFromJson(json);
            Debug.Log($"Загружен конфиг настроек");
        }
        else
        {
            Debug.LogError($"Файл {filePath} не найден!");
        }
    }

    private void SaveSettings()
    {
        string filePath = Path.Combine(gameConfigPath, "settings_config.json");

        if (File.Exists(filePath))
        {
            File.WriteAllText(filePath, settingsData.SaveToJsonString());
        }
        else
        {
            File.Create(filePath);
            File.WriteAllText(filePath, settingsData.SaveToJsonString());
            Debug.Log($"Конфиг настроек сохранен в {filePath}");
        }
    } 
}
