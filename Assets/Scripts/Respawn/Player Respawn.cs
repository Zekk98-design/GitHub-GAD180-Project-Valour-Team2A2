using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 3f;
    [SerializeField] private float spawnTimerReset = 3f;
    [SerializeField] private GameObject playerRespawnPfbWarrior;
    [SerializeField] private GameObject playerRespawnPfbRogue;
    [SerializeField] private GameObject playerRespawnPfbMage;
    private int Numlives = 3;
    private bool isAlive = true;
    private PlayerStats pStats;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pStats.health <= 0)
        {
            isAlive = false;
            Numlives = -1;
            Instantiate(playerRespawnPfbWarrior, transform.position, Quaternion.identity);
        }
    }
}
// Still need to figure out a way to make other characters to instantiate at certian conditions
//Instantiate(playerRespawnPfbRogue, transform.position, Quaternion.identity);
//Instantiate(playerRespawnPfbMage, transform.position, Quaternion.identity);