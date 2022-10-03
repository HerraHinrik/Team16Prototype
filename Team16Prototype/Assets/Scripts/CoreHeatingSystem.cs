using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreHeatingSystem : MonoBehaviour
{
    [SerializeField]public bool playerMovement;

    [SerializeField] private float maxCoreHealth;

    [SerializeField] private float currentCoreHealth;

    private void Update()
    {
        currentCoreHealth += Time.deltaTime;
    }

    private void Whatiscoreat()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("Core : " + currentCoreHealth.ToString());
        }
    }
}
