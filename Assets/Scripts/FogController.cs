using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    [SerializeField]
    private SO_GameManager gameManager;
    private void Start()
    {
        StartCoroutine(DecreaseValueOverTime());
    }

    private IEnumerator DecreaseValueOverTime()
    {
        float startTime = Time.time;

        while (RenderSettings.fogEndDistance > 0)
        {
            float elapsedTime = Time.time - startTime;
            RenderSettings.fogEndDistance = Mathf.Lerp(100, 120, elapsedTime / gameManager.Time);
            yield return null;
        }

        RenderSettings.fogEndDistance = 0;
    }
}
