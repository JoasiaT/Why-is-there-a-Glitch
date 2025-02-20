using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EndGameScreen : MonoBehaviour
{
    //public TMP_Text playerPointsText;
    // public AudioManager audioMananger;
    public GameObject player;

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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<CharacterController>().enabled = false;
    }

    public void PlayGameDEMO()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<CharacterController>().enabled = true;
        SceneManager.LoadScene("GameDEMO");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
