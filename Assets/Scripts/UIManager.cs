using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerMovment movment;
    public TMP_Text playerPointsText;
    public TMP_Text interactionText;
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;

    // Update is called once per frame
    void Update()
    {
        playerPointsText.text = movment.points.ToString();
    }

    public void SetIteractionText(string iteraction)
    {
        interactionText.text = iteraction;
    }

    public void SetDialogueText(string dialogue)
    {
        dialogueText.text = dialogue;
        if (dialogue != null && dialogue.Length > 0)
        {
            dialoguePanel.SetActive(true);
        } else
        {
            dialoguePanel.SetActive(false);
        }
    }   
}
