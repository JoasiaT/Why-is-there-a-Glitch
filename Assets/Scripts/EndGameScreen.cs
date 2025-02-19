using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EndGameScreen : MonoBehaviour
{
    public TMP_Text playerPointsText;
    // public AudioManager audioMananger;

    private void Awake()
    {
      //  audioMananger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManangare>();
    }

    public void showEndGameScreen()
    {
        //  if (audioManager != null)
        //{
            //   audioMananger.PlayMusic();
        //}
       Time.timeScale = 0;
       gameObject.SetActive(true);
    }

    public void PlayGameDEMO()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameDEMO");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
