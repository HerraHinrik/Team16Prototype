using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    // public GameObject projectilePrefab;
    [SerializeField] private float range = 100f;
    // public bool canShoot = true;
    [SerializeField] public Transform shootingPosition;
    // public GameObject player;
    [SerializeField] private float damage = 20f;
    [SerializeField] private ParticleSystem laserFlash;
    [SerializeField] private GameObject hitEffect;

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButton("Fire1") && canShoot)
        {
            Instantiate(projectilePrefab, shootingPosition.position, player.transform.rotation);
            
        }*/
         if (Input.GetButtonDown("Fire1"))
         {
             Shoot();
         }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    void Shoot()
    {
        PlayLaserFlash();
        ProcessRaycast();
    }

    void PlayLaserFlash()
    {
        laserFlash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + " was hit");
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return; 
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.identity);
        Destroy(impact, 1);
    }
}