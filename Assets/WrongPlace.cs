using UnityEngine;
using TMPro;

public class WrongPlace : MonoBehaviour
{
    public TMP_Text InfoText;
    public GameObject infoPanel;
    private float maxVisibleTime = 3.5f;
    private float timeSinceInfoVisible = 0f;

    private void Update()
    {
        timeSinceInfoVisible += Time.deltaTime;
        if (infoPanel != null && infoPanel.active)
        {
            if (timeSinceInfoVisible >= maxVisibleTime)
            {
                infoPanel.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //speed = speed * -1;
        if (other != null && other.tag == "Player")
        {
            //InfoText.SetActive(true);
            infoPanel.SetActive(true);
            timeSinceInfoVisible = 0f;
        }
    }
}
