using System.Collections;
using UnityEngine;

public class LigthVisualEffect : MonoBehaviour
{
    [SerializeField]
    private bool _doEffect;
    public Light spotlight;
    public float minIntensity = 0.2f;
    public float maxIntensity = 1.5f;
    public float flickerSpeed = 0.1f;

    private float currentIntensity;
    private float targetIntensity;

    private void Start()
    {
        currentIntensity = spotlight.intensity;
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        while (_doEffect)
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);

            float t = 0;
            while (t < 1)
            {
                t += Time.deltaTime * flickerSpeed;
                spotlight.intensity = Mathf.Lerp(currentIntensity, targetIntensity, t);
                yield return null;
            }

            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

            t = 0;
            while (t < 1)
            {
                t += Time.deltaTime * flickerSpeed;
                spotlight.intensity = Mathf.Lerp(targetIntensity, currentIntensity, t);
                yield return null;
            }

            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
        }
    }
}
