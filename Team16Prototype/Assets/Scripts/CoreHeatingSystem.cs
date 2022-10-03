using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreHeatingSystem : MonoBehaviour
{
    [SerializeField]public bool playerMovement;
    [SerializeField] private float maxCoreHealth;
    [SerializeField] private float currentCoreHealth;
    [SerializeField] private Image coreSlider;

    private void Start()
    {
        currentCoreHealth = 0f;
        playerMovement = false;
    }
    private void Update()
    {

        if (playerMovement == true)
        {
            currentCoreHealth += Time.deltaTime;
            SetSlider();
                    if (currentCoreHealth >= maxCoreHealth)
                    {
                        Debug.Log("die");
                        Destroy(gameObject);
                        
                    }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            playerMovement = true;
        }
    }

    public void SetSlider()
    {
        coreSlider.fillAmount = currentCoreHealth / maxCoreHealth;
    }
}
