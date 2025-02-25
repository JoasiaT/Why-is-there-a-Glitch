using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    //public void BackgroundMusic;

    [Header("................Audio Sorce ...................")]
    [SerializeField] public AudioMixer audioMixer;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioSource SFXSource;

    [Header("................Audio Sliders .................")]
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    [Header("................Audio Clip ....................")]
    public AudioClip mainMenuMusic;
    public AudioClip boomBox;
    public AudioClip Piano;
    public AudioClip drinkWater;
    public AudioClip paper;
    public AudioClip bubbles;
    public AudioClip makingCaffee;
    public AudioClip takePhoto;
    public AudioClip dishes;
    public AudioClip microvawe;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadMusicVolume();
        }
        else
        {
            SetMusicVolume();
        }
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadSFXVolume();
        }
        else
        {
            SetSFXVolume();
        }
        audioSource.clip = mainMenuMusic;
        PlayMusic();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }


    public void PlayMusic() 
    {
        audioSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void LoadMusicVolume()
    {
        SetMusicVolume();
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void LoadSFXVolume()
    {
        SetMusicVolume();
    }

}
