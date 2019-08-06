using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public MenuPauser menu;
    public int maxSpawn = 3;
    public int iniSpawn = 0;
    public int bbegSpawn = 0;
    public float spawnRadius = 3.0f;
    private List<Vector3> spawnPoints = new List<Vector3>();
    public GameObject charModel;
    public GameObject bbegModel;
    public Vector3 spawn;
    public Rounds rounds;
    private float spawnTimer = 1.0f;
    [SerializeField] private int upperLimit = 10;

    void Update()
    {
        if (menu.eSpawn == true)
        {
            spawnTimer = spawnTimer - Time.deltaTime;
            maxSpawn = upperLimit - GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (spawnTimer <= 0 & rounds.timer > 0)
            {
                GetLocation();
                spawnTimer = 10.0f;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the spawn radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    //Generating locations and instantiating model
    public Vector3 GetLocation()
    {
        while (iniSpawn <= maxSpawn && maxSpawn <= upperLimit)
        {
            spawn = new Vector3(Random.Range(-spawnRadius, spawnRadius), 1, Random.Range(-spawnRadius, spawnRadius));

            if (spawnPoints.Contains(spawn))
            {
                GetLocation();
            }
            else
            {
                spawnPoints.Add(spawn);
                ++iniSpawn;
                Instantiate(charModel, transform.position + spawn, transform.rotation);
            }
        }
        iniSpawn = 0;
        return spawn;
    }
}