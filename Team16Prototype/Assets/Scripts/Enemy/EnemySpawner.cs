using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject theEnemy;
    [SerializeField] private float spawnTime = 3f;
    public int xPos;
    public int zPos;
    public int enemyCount;
    
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        xPos = Random.Range(-40, 40);
        zPos = Random.Range(-40, 40);
        Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(EnemyDrop());
    }
}