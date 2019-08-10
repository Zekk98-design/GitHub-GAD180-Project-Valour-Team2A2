using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Leaderboard lBoard;
    public GameControlScript gcs;
    public float maxHealth = 20;
    public float damage = 3;
    public float defence = 20;
    public int state = 1;
    public float health;
    public Text healthText;
    private bool isDead = false;
    private int death;

    // Start is called before the first frame update
    void Start()
    {
        GameObject EGO = GameObject.Find("EGO Spawn");
        lBoard = EGO.GetComponent<Leaderboard>();
        gcs = GameObject.Find("GameControl").GetComponent<GameControlScript>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = "HP: " + health;

        if (health <= 0 & death != 2)
        {
            if (gameObject.CompareTag("Player1"))
            {
                ++lBoard.p1Death;
            }
            if (gameObject.CompareTag("Player2"))
            {
                ++lBoard.p2Death;
            }

            health = maxHealth;
            ++death;
        }

        if (health <= 0 & death == 2)
        {
            if (gameObject.CompareTag("Player1"))
            {
                lBoard.p1Death = lBoard.p1Death + 1;
            }
            if (gameObject.CompareTag("Player2"))
            {
                lBoard.p2Death = lBoard.p2Death + 1;
            }
            Destroy(gameObject);
        }
        Healthbar();
    }

    void Healthbar()
    {
        if (gameObject.CompareTag("Player1"))
        {
            if (health >= 90 && health <= 100)
            {
                GameControlScript.health = 9;
            }
            if (health >= 80 && health < 90)
            {
                GameControlScript.health = 8;
            }
            if (health >= 70 && health < 80)
            {
                GameControlScript.health = 7;
            }
            if (health >= 60 && health < 70)
            {
                GameControlScript.health = 6;
            }
            if (health >= 50 && health < 60)
            {
                GameControlScript.health = 5;
            }
            if (health >= 40 && health < 50)
            {
                GameControlScript.health = 4;
            }
            if (health >= 30 && health < 40)
            {
                GameControlScript.health = 3;
            }
            if (health >= 20 && health < 30)
            {
                GameControlScript.health = 2;
            }
            if (health >= 10 && health < 20)
            {
                GameControlScript.health = 1;
            }
            if (health > 0 && health < 10)
            {
                GameControlScript.health = 1;
            }
            if (health <= 0)
            {
                GameControlScript.health = 0;
            }
        }

        if (gameObject.CompareTag("Player2"))
        {
            if (health >= 90 && health <= 100)
            {
                GameControlScript.p2Health = 9;
            }
            if (health >= 80 && health < 90)
            {
                GameControlScript.p2Health = 8;
            }
            if (health >= 70 && health < 80)
            {
                GameControlScript.p2Health = 7;
            }
            if (health >= 60 && health < 70)
            {
                GameControlScript.p2Health = 6;
            }
            if (health >= 50 && health < 60)
            {
                GameControlScript.p2Health = 5;
            }
            if (health >= 40 && health < 50)
            {
                GameControlScript.p2Health = 4;
            }
            if (health >= 30 && health < 40)
            {
                GameControlScript.p2Health = 3;
            }
            if (health >= 20 && health < 30)
            {
                GameControlScript.p2Health = 2;
            }
            if (health >= 10 && health < 20)
            {
                GameControlScript.p2Health = 1;
            }
            if (health > 0 && health < 10)
            {
                GameControlScript.p2Health = 1;
            }
            if (health <= 0)
            {
                GameControlScript.p2Health = 0;
            }
        }
    }
}
