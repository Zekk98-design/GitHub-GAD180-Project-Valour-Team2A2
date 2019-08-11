using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlRespawnNotWorking_IdkWhy : MonoBehaviour
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
        GameObject EGO = GameObject.Find("EGO Spawn");
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
    {   //Players aer dead, destroy them...
        if (player1 != null)
        {
            if (numDeath != 0)
            {
                switch (player1.name)
                {
                    case "Warrior":
                        if (player1_Stats.health <= 0f & isP1Dead == false)
                        {
                            numDeath -= 1;
                            Destroy(player1);
                            p1WarriorisP1Dead = true;
                            isP1Dead = true;
                            ++lBoard.p1Death;
                            //Debug.Log("Player1 is destroied");
                        }
                        break;
                    case "Rogue":
                        if (player1_Stats.health <= 0f & isP1Dead == false)
                        {
                            numDeath -= 1;
                            Destroy(player1);
                            p1RogueisP1Dead = true;
                            isP1Dead = true;
                            ++lBoard.p1Death;
                            //Debug.Log("Player1 is destroied");
                        }
                        break;
                    case "Mage":
                        if (player1_Stats.health <= 0f & isP1Dead == false)
                        {
                            numDeath -= 1;
                            Destroy(player1);
                            p1MageisP1Dead = true;
                            isP1Dead = true;
                            ++lBoard.p1Death;
                        }
                        break;
                }

            }
            else
            {// Player1 no more resuraction
                print("Player rest in peace");
               
            }
        }//End player1 != null......
        else
        {
            //if Players aer dead, instantiate them...
            if (Numlives != 0 & isP1Dead == true)
            {
                //if p1WarriorisDead
                if (p1WarriorisP1Dead == true)
                {
                    Numlives -= 1;
                    // Player is dead
                    GameObject temp = Instantiate(RespawnPfbWarrior, transform.position, Quaternion.identity);
                    player1 = temp;
                    player1_Stats = temp.GetComponent<PlayerStats>();
                    temp.tag = "Player1";
                    temp.name = "Warrior";
                    player1_Stats.health = player1_Stats.maxHealth;
                    isP1Dead = false;
                    p1WarriorisP1Dead = false;
                    //Debug.Log("player1 Warrior is respawned, NumLives = " + Numlives);
                }
                if (p1RogueisP1Dead == true)
                {
                    Numlives -= 1;
                    // Player is dead
                    GameObject temp = Instantiate(RespawnPfbRogue, transform.position, Quaternion.identity);
                    player1 = temp;
                    player1_Stats = temp.GetComponent<PlayerStats>();
                    temp.tag = "Player1";
                    temp.name = "Rogue";
                    player1_Stats.health = player1_Stats.maxHealth;
                    isP1Dead = false;
                    p1RogueisP1Dead = false;
                }
                if (p1MageisP1Dead == true)
                {
                    Numlives -= 1;
                    // Player is dead
                    GameObject temp = Instantiate(RespawnPfbMage, transform.position, Quaternion.identity);
                    player1 = temp;
                    player1_Stats = temp.GetComponent<PlayerStats>();
                    temp.tag = "Player1";
                    temp.name = "Mage";
                    player1_Stats.health = player1_Stats.maxHealth;
                    isP1Dead = false;
                    p1MageisP1Dead = false;
                }

            }
            // Final destroy
            if (Numlives == 0)
            {
                if (numDeath == 0)
                {
                    switch (player1.name)
                    {
                        case "Warrior":
                            Destroy(player1);
                            ++lBoard.p1Death;
                            //Debug.Log("No more respawn.......");
                            isPlayer1FinalD = true;                     //for Enemy AI routing
                            break;
                        case "Rogue":
                            Destroy(player1);
                            ++lBoard.p1Death;
                            Debug.Log("No more respawn.......");
                            isPlayer1FinalD = true;
                            break;
                        case "Mage":
                            Destroy(player1);
                            ++lBoard.p1Death;
                            Debug.Log("No more respawn.......");
                            isPlayer1FinalD = true;
                            break;
                    }
                }
            }
        }//End else: player1= null





    }
}
