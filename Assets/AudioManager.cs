using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("................Audio Sorce ...................")]
    [SerializeField] public AudioMixer audioMixer;
    [SerializeField] public AudioSource audioSource;
    //[SerializeField] public AudioSource SFXSource;

    [Header("................Audio Clip ....................")]
    public AudioClip boomBox;

    //[Header("................Audio Sliders .................")]
    //[SerializeField] public Slider musicSlider;
    //[SerializeField] public Slider sfxSlider;

    //AudioManangare audioManangare;

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
        audioSource.clip = boomBox;
        //audioSource.Play();
    }

    //public void PlaySFX(AudioClip clip)
   // {
     //   SFXSource.PlayOneShot(clip);
    //}


    public void PlayMusic() 
    {
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void SetMusicVolume()
    {
        float volume = PlayerPrefs.GetFloat("musicVolume");
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void LoadMusicVolume()
    {
        SetMusicVolume();
    }

    public void SetSFXVolume()
    {
        float volume = PlayerPrefs.GetFloat("sfxVolume");
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void LoadSFXVolume()
    {
        SetMusicVolume();
    }

}
