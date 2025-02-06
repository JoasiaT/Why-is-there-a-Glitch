using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.TextMeshPro;

public class UIManager : MonoBehaviour
{
    public PlayerMovment movment;
    public TMP_Text playerPointsText;

    // Update is called once per frame
  void Update()
  {
     playerPointsText.text = playerMovment.points.ToString();
  }
}
