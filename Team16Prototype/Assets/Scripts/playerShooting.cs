using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    [SerializeField] private GameObject laser;
    public bool canShoot = true;
    public Transform shootingPosition;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButton("Fire1") && canShoot)
        {
            Instantiate(projectilePrefab, shootingPosition.position, player.transform.rotation);
            
        }*/
        ProcessFiring();
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            ActivateLasers();
        }
        else
        {
            DeactivateLasers();
        }
    }
    
    void ActivateLasers()
    {
        //activate laser
        laser.SetActive(true);
    }
    
    void DeactivateLasers()
    {
        laser.SetActive(false);
    }
}
