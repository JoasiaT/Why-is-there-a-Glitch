using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioMananger;


    private void Awake()
    {
        audioMananger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PlayGame()
    {
        audioMananger.StopMusic();
        SceneManager.LoadSceneAsync("GameDEMO");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}