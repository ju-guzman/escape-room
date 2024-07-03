using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_Life : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private SO_GameManager gameManager;

    private void Start()
    {
        gameManager.UpdateLife(health);
    }

    public void OnTriggerEnter(Collider other)
    {
        ValidateTrap(other.gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        ValidateTrap(collision.gameObject);
    }

    private void ValidateTrap(GameObject collision)
    {
        if (collision.CompareTag("Trap"))
        {
            health -= 10;
            gameManager.UpdateLife(health);
        }
    }
}
