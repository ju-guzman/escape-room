using UnityEngine;

public class KeyItem : MonoBehaviour, IInteract
{
    [SerializeField]
    private string _messageToShow;

    [SerializeField]
    private SO_GameManager _gameManager;

    string IInteract.GetInteractionMessage()
    {
        return _messageToShow;
    }

    void IInteract.Interact(GameObject actor)
    {
        _gameManager.OnPickupKey?.Invoke();
        _gameManager.OnEndInteraction.Invoke();
        Destroy(gameObject);
    }
}
