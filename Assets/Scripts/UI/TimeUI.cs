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
        timeText.text = time.ToString();
    }
}
