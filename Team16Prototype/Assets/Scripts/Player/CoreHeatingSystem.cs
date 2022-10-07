using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoreHeatingSystem : MonoBehaviour
{
    [SerializeField] public bool playerMovement;
    [SerializeField] private float maxCoreHealth;
    [SerializeField] private float currentCoreHealth;
    [SerializeField] private Image coreSlider;

    private Renderer _renderUI;
    private Renderer _renderPlayerCore;
    public GameObject objUI;
    public GameObject objCore;
    private void Start()
    {
        currentCoreHealth = 0.75f;
        playerMovement = false;
        Mathf.Clamp(currentCoreHealth, min: 0.75f, max: 10f);

        _renderPlayerCore = objCore.GetComponent<Renderer>();
        _renderUI = objUI.GetComponent<Renderer>();
    }

    public void TakeDamage(float damage)
    {
        currentCoreHealth += damage;
        Debug.Log("biib");
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
                        LoadDeath();
                    }
        }
        else if (currentCoreHealth >= 0.5f)
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
        _renderPlayerCore.material.SetFloat("_CoreStatus", currentCoreHealth/maxCoreHealth);
    }

    public void SetSlider()
    {
        coreSlider.fillAmount = currentCoreHealth / maxCoreHealth;
    }
   

    void LoadDeath()
    {
        SceneManager.LoadScene(2);
    }
}
