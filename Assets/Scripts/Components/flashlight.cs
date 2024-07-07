using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class flashlight : MonoBehaviour
{
    [SerializeField]
    private Light _flashlight;
    [SerializeField]
    private SO_GameManager _gameManager;
    [SerializeField] 
    private SO_Inputs inputs;

    private bool _currentStatus = false;
    private bool _isflashLightEnable = false;

    private void Start()
    {
        inputs.OnLightPress += onSwicthPressed;
        _gameManager.OnPickupFalshLight += PickupFlashLight;
    }

    private void PickupFlashLight()
    {
        _isflashLightEnable = true;
    }

    public void onSwicthPressed ()
    {
        if (!_isflashLightEnable)
            return;
        SwicthLigthEffect();
    }

    private void SwicthLigthEffect ()
    {
        _currentStatus = !_currentStatus;
        _flashlight.enabled = _currentStatus;
    }

}
