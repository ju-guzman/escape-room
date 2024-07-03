using System;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private SO_GameManager gameManager;
    [SerializeField] private TextMeshProUGUI timeText;

    private void OnEnable()
    {
        gameManager.OnTimeChange += UpdateTime;
    }

    private void OnDisable()
    {
        gameManager.OnTimeChange -= UpdateTime;
    }

    private void UpdateTime(int time)
    {
        TimeSpan timespan = TimeSpan.FromSeconds(time);
        timeText.text = timespan.ToString(@"mm\:ss");
    }
}
