using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemController : MonoBehaviour
{
    [SerializeField]
    private SO_GameManager _gameManager;

    [SerializeField]
    private GameObject _imageKey;
    [SerializeField]
    private GameObject _imageFlashLight;

    private void Start()
    {
        _gameManager.OnPickupKey += PickupKey;
        _gameManager.OnLostKey += LostKey;
        _gameManager.OnPickupFalshLight += PickupFlashLight;
    }

    private void LostKey()
    {
        _imageKey.SetActive(false);
    }

    private void PickupKey()
    {
        _imageKey.SetActive(true);
    }
    private void PickupFlashLight()
    {
        _imageFlashLight.SetActive(true);
    }
}
