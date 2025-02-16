using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerMovment movment;
    public TMP_Text playerPointsText;
    public TMP_Text interactionText;
    public TMP_Text dialogueText;

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

    }
   
   
}
