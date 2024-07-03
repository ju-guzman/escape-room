using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "ScriptableObjects/GameManager", order = 1)]
public class SO_GameManager : ScriptableObject
{
    [Header("Game settings")]
    [SerializeField] private int time = 120;

    private int currentTime;

    private void OnEnable()
    {
        currentTime = time;
    }

    #region Time

    public Action<int> OnTimeChange;
    public Action OnTimeEnd;

    public int Time
    {
        get => currentTime;
        set
        {
            currentTime = value;
            OnTimeChange?.Invoke(currentTime);
            if (currentTime <= 0)
            {
                OnTimeEnd?.Invoke();
                GameOver();
            }
        }
    }
    #endregion

    #region Player
    #region flashlight
    public bool HaveFlashlight = false;
    #endregion
    #region life
    public Action<int> OnPlayerLifeChange;

    public void UpdateLife(int life)
    {
        if (life <= 0)
        {
            GameOver();
        }
        OnPlayerLifeChange?.Invoke(life);
    }
    #endregion
    #region interaction
    public Action<string> OnStartInteraction;
    public Action OnEndInteraction;

    public void StartInteraction(string message)
    {
        OnStartInteraction?.Invoke(message);
    }

    public void EndInteraction()
    {
        OnEndInteraction?.Invoke();
    }
    #endregion
    #endregion

    #region Game state
    public Action OnGameOver;
    public Action OnGameStart;

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentTime = time;
        OnGameStart?.Invoke();
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        OnGameOver?.Invoke();
    }
    #endregion
}
