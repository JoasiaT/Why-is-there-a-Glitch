using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerMovment movment;
    public TMP_Text playerPointsText;
    public TMP_Text interactionText;

    // Update is called once per frame
    void Update()
    {
        playerPointsText.text = movment.points.ToString();
    }

    public void SetIteractionText(string iteraction)
    {
        interactionText.text = iteraction;
    }

}
