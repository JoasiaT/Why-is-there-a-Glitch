using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerMovment movment;
    public TMP_Text playerPointsText;

    // Update is called once per frame
    void Update()
    {
        playerPointsText.text = movment.points.ToString();
    }

}
