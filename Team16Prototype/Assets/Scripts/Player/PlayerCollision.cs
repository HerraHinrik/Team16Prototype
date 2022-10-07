using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] public GameObject hitEffect;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GameObject playerHit = Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            playerHit.GetComponent<ParticleSystem>().Play();
        }
    }
}
