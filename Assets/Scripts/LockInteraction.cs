using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockInteraction : MonoBehaviour, IInteract
{
    private bool _islocked = true;

    [SerializeField]
    private string _messageLockedToShow;
    [SerializeField]
    private string _messageUnlockedToShow;

    [SerializeField]
    private SO_GameManager _gameManager;

    private void Start()
    {
        _gameManager.OnPickupKey += PickupKey;
    }

    private void PickupKey()
    {
        _islocked = false;
    }

    string IInteract.GetInteractionMessage()
    {
        if (_islocked)
        {
            return _messageLockedToShow;
        }
        return _messageUnlockedToShow;
    }

    void IInteract.Interact(GameObject actor)
    {
        if (_islocked)
        {
            return;
        }
        _gameManager.OnLockerOpen?.Invoke();
        _gameManager.OnEndInteraction?.Invoke();
        _gameManager.OnLostKey?.Invoke();
        Destroy(gameObject);
    }
}
