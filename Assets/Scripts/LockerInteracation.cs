using UnityEngine;

public class LockerInteracation : MonoBehaviour
{
    [SerializeField]
    private SO_GameManager _gameManager;

    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioSource _audioSourceDoor;
    [SerializeField]
    private GameObject _finalKey;
    [SerializeField]
    private Animator _animator;

    void Start()
    {
        _gameManager.OnLockerOpen += OpenLocker;
    }

    private void OpenLocker()
    {
        _animator.SetTrigger("Open");
        _audioSource.Play();
        _audioSourceDoor.Play();
        _finalKey.SetActive(true);
    }
}
