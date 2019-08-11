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
    private GameObject Player2;
    private PlayerStats player1_Stats, player2_Stats;

    public static int health;
    public static int p2Health;

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
        player1_Stats = Player1.GetComponent<PlayerStats>();
        player2_Stats = Player2.GetComponent<PlayerStats>();

    }

    void Update()
    {
        if (player1_Stats.death == 0)
        {
            life3.gameObject.SetActive(false);
        }
        if (player1_Stats.death == 1)
        {
            life2.gameObject.SetActive(false); ;
        }

        if (player2_Stats.death == 0)
        {
            life6.gameObject.SetActive(false);
        }
        if (player2_Stats.death == 1)
        {
            life5.gameObject.SetActive(false);
        }

        if (player1_Stats.death == 2)
        {
            life1.gameObject.SetActive(false);
        }
        if (player2_Stats.death == 2)
        {
            life4.gameObject.SetActive(false);
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