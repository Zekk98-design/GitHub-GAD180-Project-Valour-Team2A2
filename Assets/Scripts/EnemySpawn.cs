using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public MenuPauser menu;
    public int maxSpawn = 3;
    public int iniSpawn = 0;
    public int bbegSpawn = 0;
    public float spawnRadius = 5.2f;
    private List<Vector3> spawnPoints = new List<Vector3>();
    public GameObject charModel;
    public GameObject bbegModel;
    public Vector3 spawn;
    public Rounds rounds;
    private float spawnTimer = 1.0f;
    [SerializeField] private int upperLimit = 10;
    //Boss Var
    [SerializeField] bool isBossCrreated;
    [SerializeField] int _RoundtoInstantiateBoss=1;

    private void Start()
    {
        isBossCrreated = false;
    }
    void Update()
    {
        if (menu.eSpawn == true)
        {
            spawnTimer = spawnTimer - Time.deltaTime;
            maxSpawn = upperLimit - GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (spawnTimer <= 0 & rounds.timer > 0)
            {
                GetLocation();
                InstantiateBoss();
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
            spawn = new Vector3(6f + Random.Range(-spawnRadius, spawnRadius), 0.4f, Random.Range(-spawnRadius, spawnRadius));

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

    //Added by Bruce
    private void InstantiateBoss()  
    {
        if (rounds.roundCount == _RoundtoInstantiateBoss)
        {
            if (isBossCrreated == true) {   }
            else
            {
                Instantiate(bbegModel, transform.position+ spawn, transform.rotation);
                isBossCrreated = true;
            }
            
        }   
    }
}