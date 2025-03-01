using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public static SoundManager Instance { get; private set; }

    public AudioSource audioSource;

    [SerializeField] private AudioClip[] _audioClips;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
