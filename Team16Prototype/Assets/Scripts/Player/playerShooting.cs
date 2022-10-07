using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    [SerializeField] private float range = 100f;
    [SerializeField] private float lineRange = 100f;
    [SerializeField] public Transform shootingPosition;
    [SerializeField] private float damage = 50f;
    [SerializeField] private ParticleSystem laserFlash;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform shootingRotation;
    public AudioSource bulletSound;

    // Update is called once per frame
    void Update()
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position + transform.forward * lineRange;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            bulletSound.Play();
            Debug.Log("shoot");
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