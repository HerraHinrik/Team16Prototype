using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    private Rigidbody projectileBody;
    private float projectileShootForce = 1000f;
    public bool canShoot = true;
    public Transform shootingPosition;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        projectileBody = GetComponent<Rigidbody>();
        projectileBody.AddRelativeForce(Vector3.forward * projectileShootForce);

        StartCoroutine(WaitToDestroy());


    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(3f);

        //Destroy(gameObject);
    }

}
