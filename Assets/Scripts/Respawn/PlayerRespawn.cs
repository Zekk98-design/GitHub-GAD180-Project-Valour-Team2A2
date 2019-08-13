using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this to EGO respawn 
/// </summary>
public class PlayerRespawn : MonoBehaviour
{
    //[SerializeField] private float spawnTimer = 2f;
    //[SerializeField] private float spawnTimerReset = 2f;
    [SerializeField] private GameObject RespawnPfbWarrior;
    [SerializeField] private GameObject RespawnPfbRogue;
    [SerializeField] private GameObject RespawnPfbMage;
    public Leaderboard lBoard;
    private GameControlScript gameControlScript;

    private int Numlives;
    private PlayerStats player1_Stats, player2_Stats;
    private GameObject player1, player2;

    private int numDeath;
    private bool isP1Dead = false;
    private bool isP2Dead = false;

    bool p1WarriorisP1Dead = false;
    bool p1RogueisP1Dead = false;
    bool p1MageisP1Dead = false;
    bool p2WarriorisP1Dead = false;
    bool p2RogueisP1Dead = false;
    bool p2MageisP1Dead = false;


    public bool isPlayer1FinalD = false;          //for Enemy AI routing
    public bool isPlayer2FinalD = false;
 


    // Start is called before the first frame update
    void Start()
    {
        GameObject EGO = GameObject.Find("Game Manager");
        lBoard = EGO.GetComponent<Leaderboard>();
        GameObject temp = GameObject.Find("GameControlHealth");
        gameControlScript = temp.GetComponent<GameControlScript>();
        Numlives = 3;
        numDeath = 3;
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player1_Stats = player1.GetComponent<PlayerStats>();
        player2_Stats = player2.GetComponent<PlayerStats>();
        
    }

    void Update()
    {   



    }
}
