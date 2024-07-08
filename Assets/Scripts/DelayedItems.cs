using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedItems : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemsToEnable;

    [SerializeField]
    private float delay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnableItems());
    }

    private IEnumerator EnableItems()
    {
        yield return new WaitForSeconds(delay);
        foreach (var item in itemsToEnable)
        {
            item.SetActive(true);
        }
    }
}
