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
        currentCoreHealth = 0.75f;
        playerMovement = false;
        Mathf.Clamp(currentCoreHealth, min: 0.75f, max: 10f);
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
        else if (currentCoreHealth >= 1.75f)
        {
            currentCoreHealth -= Time.deltaTime;
            SetSlider();
        }
        else
        {
            //Debug.Log("zero");
        }
       
   
        if (Input.GetAxisRaw("Horizontal") >= 0.1f)
        {
            playerMovement = true;
        }
        else
        {
            playerMovement = false;
        }
        if (Input.GetAxisRaw("Horizontal") <= -0.1f)
        {
            playerMovement = true;
        }

        if (Input.GetAxisRaw("Vertical") >= 0.1f)
        {
            playerMovement = true;
        }
        if (Input.GetAxisRaw("Vertical") <= -0.1f)
        {
            playerMovement = true;
        }
    }

    public void SetSlider()
    {
        coreSlider.fillAmount = currentCoreHealth / maxCoreHealth;
    }
}
