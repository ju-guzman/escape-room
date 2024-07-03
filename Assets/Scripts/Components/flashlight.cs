using UnityEngine;

public class flashlight : MonoBehaviour
{
    [SerializeField]
    private Light _flashlight;

    private bool _currentStatus = false;
    private bool _isflashLightEnable = false;

    public void onSwicthPressed ()
    {
        Debug.Log("asd");
        SwicthLigthEffect();
    }

    private void SwicthLigthEffect ()
    {
        _currentStatus = !_currentStatus;
        _flashlight.enabled = _currentStatus;
    }

}
