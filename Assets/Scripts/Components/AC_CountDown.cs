using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_CountDownTime : MonoBehaviour
{
    [SerializeField] private SO_GameManager gameManager;
    // Start is called before the first frame update
    private void OnEnable()
    {
        gameManager.OnGameOver += OnTimeEnd;
        gameManager.OnTimeEnd += OnTimeEnd;
    }

    private void OnTimeEnd(int score)
    {
        OnTimeEnd();
    }

    private void OnDisable()
    {
        gameManager.OnTimeEnd -= OnTimeEnd;
        gameManager.OnGameOver -= OnTimeEnd;
    }

    void Start()
    {
        StartCoroutine(CountDown());
    }

    private void OnTimeEnd()
    {
        StopAllCoroutines();
    }

    private IEnumerator CountDown()
    {
        while (gameManager.Time > 0)
        {
            yield return new WaitForSeconds(1);
            gameManager.Time--;
        }
    }
}
