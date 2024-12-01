using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    internal static AudioManager instance;

    public enum MusicClips
    {
        MainMenu,
        Challenge,
        Hard,
        End
    }

    public enum SoundEffects
    {
        Error,
        Success,
        KeyPress,
        KeyRelease,
        Fail
    }

    [Header("Music")]
    public AudioSource musicAudioSource;
    [SerializeField] AudioClip[] musicAudioClips;

    [Header("SFX")]
    [SerializeField] AudioSource[] sfxAudioSources;

    public static float musicVolume = 0.5f;
    public static float sfxVolume = 0.5f;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayMusic(MusicClips.MainMenu);
        }
        else if (SceneManager.GetActiveScene().name == "LevelMain")
        {
            PlayMusic(MusicClips.End);
        }
        else if (SceneManager.GetActiveScene().name == "LevelHard")
        {
            PlayMusic(MusicClips.Hard);
        }
    }

    private void Update()
    {
        if (InputManager.GetPlayerPress())
        {
            PlaySFX(SoundEffects.KeyPress);
        }

        if (InputManager.GetPlayerRelease())
        {
            PlaySFX(SoundEffects.KeyRelease);
        }
    }

    public void PlayMusic(MusicClips musicClip)
    {
        musicAudioSource.clip = musicAudioClips[(int)musicClip];
        musicAudioSource.Play();
    }

    public void PlaySFX(SoundEffects soundEffects)
    {
        sfxAudioSources[(int)soundEffects].PlayOneShot(instance.sfxAudioSources[(int)soundEffects].clip);
    }
}