using UnityEngine;

public class FlashLightItem : MonoBehaviour, IInteract
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
        Destroy(gameObject);
        _gameManager.HaveFlashlight = true;
    }
}
