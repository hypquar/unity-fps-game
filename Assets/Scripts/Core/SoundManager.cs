using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource audioSource;
    public List<Sound> soundList;

    private Dictionary<string, AudioClip> soundDictionary;

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

        foreach (var sound in soundList)
        {
            soundDictionary[sound.name] = sound.clip;
        }
    }

    public void PlaySound(string soundName)
    {
        if (soundDictionary.TryGetValue(soundName, out AudioClip audioClip))
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
    
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
    }
}
