using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_Iterator : MonoBehaviour
{
    [SerializeField] private SO_GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            gameManager.GameOver();
        }
        other.GetComponent<IInteract>()?.Interact(gameObject);
    }
}
