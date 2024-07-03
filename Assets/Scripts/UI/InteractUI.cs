using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    [SerializeField] private SO_GameManager gameManager;
    [SerializeField] private TextMeshProUGUI interactText;

    private void OnEnable()
    {
        gameManager.OnStartInteraction += UpdateTime;
        gameManager.OnEndInteraction += ClearText;
    }

    private void OnDisable()
    {
        gameManager.OnStartInteraction -= UpdateTime;
        gameManager.OnEndInteraction -= ClearText;
    }

    private void ClearText()
    {
        interactText.text = "";
    }

    private void UpdateTime(string message)
    {
        interactText.text = message;
    }
}
