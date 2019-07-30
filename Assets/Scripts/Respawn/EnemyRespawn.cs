using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 3f;
    [SerializeField] private float spawnTimerReset = 3f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemyCounter = 0;

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            spawnTimer = spawnTimerReset;
           
            StartCoroutine(CoSpawn());
        }
    }

    IEnumerator CoSpawn()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject newChicken = Instantiate(enemyPrefab, transform.position + new Vector3(Random.Range(-30, 30), 0, Random.Range(-20, 20)), Quaternion.identity) as GameObject;
            newChicken.name = "Chicken " + enemyCounter;
            enemyCounter++;

        }

        yield return 0;
    }
}
