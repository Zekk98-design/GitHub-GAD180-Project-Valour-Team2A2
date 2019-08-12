using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour
{
    // Controls player health UI; activation and deactivation of images/bars to show health gain and loss.
    // Attach to empty game object in both level scenes.
    // References health gain (red potions) and death (enemies) scripts.

    public GameObject bar1, bar2, bar3, bar4, bar5, bar6, bar7, bar8, bar9, gameOver;
    public GameObject p2Bar1, p2Bar2, p2Bar3, p2Bar4, p2Bar5, p2Bar6, p2Bar7, p2Bar8, p2Bar9, p2GameOver;
    public GameObject life1, life2, life3, life4, life5, life6;

    private GameObject Player1;
    private GameObject Player2, playerNull;
    private PlayerStats player1_Stats, player2_Stats,playerNull_Stats;

    public static int health;
    public static int p2Health;
    int p1LifeCounter = 0;
    int p2LifeCounter = 0;
   
    public GameObject _DeathSkull;
    GameObject skull;
    GameObject skull2;
    GameObject skull3;
    GameObject skull4;
    GameObject skull5;
    GameObject skull6;

    int skullCounter=0;
    int skullCounter2 = 0;

    void Start()
    {
        health = 10;
        bar1.gameObject.SetActive(true);
        bar2.gameObject.SetActive(true);
        bar3.gameObject.SetActive(true);
        bar4.gameObject.SetActive(true);
        bar5.gameObject.SetActive(true);
        bar6.gameObject.SetActive(true);
        bar7.gameObject.SetActive(true);
        bar8.gameObject.SetActive(true);
        bar9.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);

        p2Health = 10;
        p2Bar1.gameObject.SetActive(true);
        p2Bar2.gameObject.SetActive(true);
        p2Bar3.gameObject.SetActive(true);
        p2Bar4.gameObject.SetActive(true);
        p2Bar5.gameObject.SetActive(true);
        p2Bar6.gameObject.SetActive(true);
        p2Bar7.gameObject.SetActive(true);
        p2Bar8.gameObject.SetActive(true);
        p2Bar9.gameObject.SetActive(true);
        p2GameOver.gameObject.SetActive(false);

        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        playerNull = GameObject.FindGameObjectWithTag("EGO_Null_Player");
        player1_Stats = Player1.GetComponent<PlayerStats>();
        player2_Stats = Player2.GetComponent<PlayerStats>();
        playerNull_Stats = playerNull.GetComponent<PlayerStats>();
    }

    void Update()
    {
        // To disable Life UI when consumes life...
        if (Player1 != null)
        {
            Player1 = GameObject.FindGameObjectWithTag("Player1");
            player1_Stats = Player1.GetComponent<PlayerStats>();
            if (player1_Stats.health <= 0)
            {
                //Debug.Log("P1 HP in GamecontrolSript = " + player1_Stats.health);
                p1LifeCounter++;
                switch (p1LifeCounter)
                {
                    case 1:
                        life3.gameObject.SetActive(false);
                        skull = Instantiate(_DeathSkull, Player1.transform.position+new Vector3(0f,2f,0f), Quaternion.Euler(90f, 0f, 0f));
                        skull.name = "skull_01";
                        skullCounter++;
                        break;
                    case 2:
                        life2.gameObject.SetActive(false);
                        skull2 = Instantiate(_DeathSkull, Player1.transform.position + new Vector3(0f, 2f, 0f), Quaternion.Euler(90f, 0f, 0f));
                        skull2.name = "skull_02";
                        skullCounter++;
                        break;
                    case 3:
                        life1.gameObject.SetActive(false);
                        skull3 = Instantiate(_DeathSkull, Player1.transform.position + new Vector3(0.1f, 2f, 0f), Quaternion.Euler(90f, 0f, 0f));
                        skull3.name = "skull_03";
                        skullCounter++;
                        //Debug.Log("skullcounter in case3 = " + skullCounter);
                        break;
                }
            }
            if (skullCounter == 1)
            {
                skull.transform.Translate(new Vector3(0, 0, -1f) * 4f * Time.deltaTime);
            }
            else if (skullCounter == 2)
            {
                skull2.gameObject.transform.Translate(new Vector3(0, 0, -1f) * 4f * Time.deltaTime);
            }
            else if (skullCounter == 3)
            {
                skull3.gameObject.transform.Translate(new Vector3(0, 0, -1f) * 4f * Time.deltaTime);
            }
        }
        else
        {
            Player1 = playerNull;
            player1_Stats = playerNull_Stats;
            Debug.Log("Player1 is null");
        }

        
        if (Player2 != null)
        {
            Player2 = GameObject.FindGameObjectWithTag("Player2");
            player2_Stats = Player2.GetComponent<PlayerStats>();
            if (player2_Stats.health <= 0)
            {
                Debug.Log("P2 HP in GamecontrolSript = " + player2_Stats.health);
                p2LifeCounter++;
                switch (p2LifeCounter)
                {
                    case 1:
                        life6.gameObject.SetActive(false);
                        skull4 = Instantiate(_DeathSkull, Player2.transform.position + new Vector3(0f, 2f, 0f), Quaternion.Euler(90f, 0f, 0f));
                        skull4.name = "skull_04";
                        skullCounter2++;
                        break;
                    case 2:
                        life5.gameObject.SetActive(false);
                        skull5 = Instantiate(_DeathSkull, Player2.transform.position + new Vector3(0f, 2f, 0f), Quaternion.Euler(90f, 0f, 0f));
                        skull5.name = "skull_05";
                        skullCounter2++;
                        //Debug.Log("Player2 case2 life5 should be deleted.");
                        break;
                    case 3:
                        life4.gameObject.SetActive(false);
                        skull6 = Instantiate(_DeathSkull, Player2.transform.position + new Vector3(0f, 2f, 0f), Quaternion.Euler(90f, 0f, 0f));
                        skull6.name = "skull_06";
                        skullCounter2++;
                        break;
                }
            }
            if (skullCounter2 == 1)
            {
                skull4.gameObject.transform.Translate(new Vector3(0, 0, -1f) * 4f * Time.deltaTime);
            }
            else if (skullCounter2 == 2)
            {
                skull5.gameObject.transform.Translate(new Vector3(0, 0, -1f) * 4f * Time.deltaTime);
            }
            else if (skullCounter2 == 3)
            {
                skull6.gameObject.transform.Translate(new Vector3(0, 0, -1f) * 4f * Time.deltaTime);
            }
        }
        else
        {
            Player2 = playerNull;
            player2_Stats = playerNull_Stats;
            Debug.Log("Player2 is null");
        }


        // P1.
        if (health > 9)
            health = 9;
        if (GameControlScriptShield.shield < 1)
        {
            switch (health)
            {
                case 9:
                    bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(true);
                bar5.gameObject.SetActive(true);
                bar6.gameObject.SetActive(true);
                bar7.gameObject.SetActive(true);
                bar8.gameObject.SetActive(true);
                bar9.gameObject.SetActive(true);
                break;
                case 8:
                    bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(true);
                bar5.gameObject.SetActive(true);
                bar6.gameObject.SetActive(true);
                bar7.gameObject.SetActive(true);
                bar8.gameObject.SetActive(true);
                bar9.gameObject.SetActive(false);
                break;
                case 7:
                    bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(true);
                bar5.gameObject.SetActive(true);
                bar6.gameObject.SetActive(true);
                bar7.gameObject.SetActive(true);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
                case 6:
                    bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(true);
                bar5.gameObject.SetActive(true);
                bar6.gameObject.SetActive(true);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
                case 5:
                    bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(true);
                bar5.gameObject.SetActive(true);
                bar6.gameObject.SetActive(false);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
                case 4:
                    bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(true);
                bar5.gameObject.SetActive(false);
                bar6.gameObject.SetActive(false);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
                case 3:
                    bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(true);
                bar4.gameObject.SetActive(false);
                bar5.gameObject.SetActive(false);
                bar6.gameObject.SetActive(false);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
                case 2:
                    bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(true);
                bar3.gameObject.SetActive(false);
                bar4.gameObject.SetActive(false);
                bar5.gameObject.SetActive(false);
                bar6.gameObject.SetActive(false);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
                case 1:
                    bar1.gameObject.SetActive(true);
                bar2.gameObject.SetActive(false);
                bar3.gameObject.SetActive(false);
                bar4.gameObject.SetActive(false);
                bar5.gameObject.SetActive(false);
                bar6.gameObject.SetActive(false);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                break;
                case 0:
                    bar1.gameObject.SetActive(false);
                bar2.gameObject.SetActive(false);
                bar3.gameObject.SetActive(false);
                bar4.gameObject.SetActive(false);
                bar5.gameObject.SetActive(false);
                bar6.gameObject.SetActive(false);
                bar7.gameObject.SetActive(false);
                bar8.gameObject.SetActive(false);
                bar9.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                break;
            }
        }
        if (health > 0)
        {
            gameOver.gameObject.SetActive(false);
        }
        // P2.
        if (p2Health > 9)
            p2Health = 9;
        switch (p2Health)
        {
            case 9:
                p2Bar1.gameObject.SetActive(true);
                p2Bar2.gameObject.SetActive(true);
                p2Bar3.gameObject.SetActive(true);
                p2Bar4.gameObject.SetActive(true);
                p2Bar5.gameObject.SetActive(true);
                p2Bar6.gameObject.SetActive(true);
                p2Bar7.gameObject.SetActive(true);
                p2Bar8.gameObject.SetActive(true);
                p2Bar9.gameObject.SetActive(true);
                p2GameOver.gameObject.SetActive(false);
                break;
            case 8:
                p2Bar1.gameObject.SetActive(true);
                p2Bar2.gameObject.SetActive(true);
                p2Bar3.gameObject.SetActive(true);
                p2Bar4.gameObject.SetActive(true);
                p2Bar5.gameObject.SetActive(true);
                p2Bar6.gameObject.SetActive(true);
                p2Bar7.gameObject.SetActive(true);
                p2Bar8.gameObject.SetActive(true);
                p2Bar9.gameObject.SetActive(false);
                p2GameOver.gameObject.SetActive(false);
                break;
            case 7:
                p2Bar1.gameObject.SetActive(true);
                p2Bar2.gameObject.SetActive(true);
                p2Bar3.gameObject.SetActive(true);
                p2Bar4.gameObject.SetActive(true);
                p2Bar5.gameObject.SetActive(true);
                p2Bar6.gameObject.SetActive(true);
                p2Bar7.gameObject.SetActive(true);
                p2Bar8.gameObject.SetActive(false);
                p2Bar9.gameObject.SetActive(false);
                p2GameOver.gameObject.SetActive(false);
                break;
            case 6:
                p2Bar1.gameObject.SetActive(true);
                p2Bar2.gameObject.SetActive(true);
                p2Bar3.gameObject.SetActive(true);
                p2Bar4.gameObject.SetActive(true);
                p2Bar5.gameObject.SetActive(true);
                p2Bar6.gameObject.SetActive(true);
                p2Bar7.gameObject.SetActive(false);
                p2Bar8.gameObject.SetActive(false);
                p2Bar9.gameObject.SetActive(false);
                p2GameOver.gameObject.SetActive(false);
                break;
            case 5:
                p2Bar1.gameObject.SetActive(true);
                p2Bar2.gameObject.SetActive(true);
                p2Bar3.gameObject.SetActive(true);
                p2Bar4.gameObject.SetActive(true);
                p2Bar5.gameObject.SetActive(true);
                p2Bar6.gameObject.SetActive(false);
                p2Bar7.gameObject.SetActive(false);
                p2Bar8.gameObject.SetActive(false);
                p2Bar9.gameObject.SetActive(false);
                p2GameOver.gameObject.SetActive(false);
                break;
            case 4:
                p2Bar1.gameObject.SetActive(true);
                p2Bar2.gameObject.SetActive(true);
                p2Bar3.gameObject.SetActive(true);
                p2Bar4.gameObject.SetActive(true);
                p2Bar5.gameObject.SetActive(false);
                p2Bar6.gameObject.SetActive(false);
                p2Bar7.gameObject.SetActive(false);
                p2Bar8.gameObject.SetActive(false);
                p2Bar9.gameObject.SetActive(false);
                p2GameOver.gameObject.SetActive(false);
                break;
            case 3:
                p2Bar1.gameObject.SetActive(true);
                p2Bar2.gameObject.SetActive(true);
                p2Bar3.gameObject.SetActive(true);
                p2Bar4.gameObject.SetActive(false);
                p2Bar5.gameObject.SetActive(false);
                p2Bar6.gameObject.SetActive(false);
                p2Bar7.gameObject.SetActive(false);
                p2Bar8.gameObject.SetActive(false);
                p2Bar9.gameObject.SetActive(false);
                p2GameOver.gameObject.SetActive(false);
                break;
            case 2:
                p2Bar1.gameObject.SetActive(true);
                p2Bar2.gameObject.SetActive(true);
                p2Bar3.gameObject.SetActive(false);
                p2Bar4.gameObject.SetActive(false);
                p2Bar5.gameObject.SetActive(false);
                p2Bar6.gameObject.SetActive(false);
                p2Bar7.gameObject.SetActive(false);
                p2Bar8.gameObject.SetActive(false);
                p2Bar9.gameObject.SetActive(false);
                p2GameOver.gameObject.SetActive(false);
                break;
            case 1:
                p2Bar1.gameObject.SetActive(true);
                p2Bar2.gameObject.SetActive(false);
                p2Bar3.gameObject.SetActive(false);
                p2Bar4.gameObject.SetActive(false);
                p2Bar5.gameObject.SetActive(false);
                p2Bar6.gameObject.SetActive(false);
                p2Bar7.gameObject.SetActive(false);
                p2Bar8.gameObject.SetActive(false);
                p2Bar9.gameObject.SetActive(false);
                p2GameOver.gameObject.SetActive(false);
                break;
            case 0:
                p2Bar1.gameObject.SetActive(false);
                p2Bar2.gameObject.SetActive(false);
                p2Bar3.gameObject.SetActive(false);
                p2Bar4.gameObject.SetActive(false);
                p2Bar5.gameObject.SetActive(false);
                p2Bar6.gameObject.SetActive(false);
                p2Bar7.gameObject.SetActive(false);
                p2Bar8.gameObject.SetActive(false);
                p2Bar9.gameObject.SetActive(false);
                p2GameOver.gameObject.SetActive(true);
                break;
        }
        if (p2Health > 0)
        {
            p2GameOver.gameObject.SetActive(false);
        }


       


    }
}