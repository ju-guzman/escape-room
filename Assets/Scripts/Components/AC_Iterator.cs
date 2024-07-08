using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_Iterator : MonoBehaviour
{
    [SerializeField] private SO_Inputs inputs;
    [SerializeField] private SO_GameManager gameManager;

    private IInteract interactable;

    private void OnEnable()
    {
        inputs.OnInteract += Interact;
    }

    private void OnDisable()
    {
        inputs.OnInteract -= Interact;
    }

    private void Interact()
    {
        if (interactable != null && !interactable.Equals(null))
        {
            interactable?.Interact(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            gameManager.GameOver();
        }
        interactable = other.GetComponent<IInteract>();
        if (interactable != null)
        {
            gameManager.StartInteraction(interactable.GetInteractionMessage());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactable = null;
        gameManager.EndInteraction();
    }
}
