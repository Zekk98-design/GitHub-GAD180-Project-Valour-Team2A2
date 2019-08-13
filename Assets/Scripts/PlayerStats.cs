using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>

public class PlayerStats : MonoBehaviour
{
    public Leaderboard lBoard;
    public GameControlScript gcs;
    public UIHealth uiHealth;

    public float maxHealth = 20f;
    public float health;
    public float maxDefence = 20f;
    public float defence;
    public float damage = 3;
    public int state = 1;
    public Text healthText;

    private GameControlScript gameControlScript;

    public bool isPlayer1FinalD = false;          //for Enemy AI routing
    public bool isPlayer2FinalD = false;

    public int death=0;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        defence = maxDefence;
             
        GameObject EGO = GameObject.Find("EGO Spawn");
        lBoard = EGO.GetComponent<Leaderboard>();
        uiHealth = EGO.GetComponent<UIHealth>();
        gcs = GameObject.Find("GameControl").GetComponent<GameControlScript>();

        UIInit();

    }

    void Update()
    {
        //healthText.text = "HP: " + health; for testing purpose
        StatCheck();
        Healthbar();
        Shieldbar();
    }

    void UIInit()
    {
        uiHealth.bar1.gameObject.SetActive(true);
        uiHealth.bar2.gameObject.SetActive(true);
        uiHealth.bar3.gameObject.SetActive(true);
        uiHealth.bar4.gameObject.SetActive(true);
        uiHealth.bar5.gameObject.SetActive(true);
        uiHealth.bar6.gameObject.SetActive(true);
        uiHealth.bar7.gameObject.SetActive(true);
        uiHealth.bar8.gameObject.SetActive(true);
        uiHealth.bar9.gameObject.SetActive(true);
        uiHealth.gameOver.gameObject.SetActive(false);

        uiHealth.p2Bar1.gameObject.SetActive(true);
        uiHealth.p2Bar2.gameObject.SetActive(true);
        uiHealth.p2Bar3.gameObject.SetActive(true);
        uiHealth.p2Bar4.gameObject.SetActive(true);
        uiHealth.p2Bar5.gameObject.SetActive(true);
        uiHealth.p2Bar6.gameObject.SetActive(true);
        uiHealth.p2Bar7.gameObject.SetActive(true);
        uiHealth.p2Bar8.gameObject.SetActive(true);
        uiHealth.p2Bar9.gameObject.SetActive(true);
        uiHealth.p2GameOver.gameObject.SetActive(false);

        uiHealth.shield1.gameObject.SetActive(true);
        uiHealth.shield2.gameObject.SetActive(true);
        uiHealth.shield3.gameObject.SetActive(true);
        uiHealth.shield4.gameObject.SetActive(true);
        uiHealth.shield5.gameObject.SetActive(true);
        uiHealth.shield6.gameObject.SetActive(true);
        uiHealth.shield7.gameObject.SetActive(true);
        uiHealth.shield8.gameObject.SetActive(true);
        uiHealth.shield9.gameObject.SetActive(true);
        uiHealth.shieldGone.gameObject.SetActive(false);

        uiHealth.p2Shield1.gameObject.SetActive(true);
        uiHealth.p2Shield2.gameObject.SetActive(true);
        uiHealth.p2Shield3.gameObject.SetActive(true);
        uiHealth.p2Shield4.gameObject.SetActive(true);
        uiHealth.p2Shield5.gameObject.SetActive(true);
        uiHealth.p2Shield6.gameObject.SetActive(true);
        uiHealth.p2Shield7.gameObject.SetActive(true);
        uiHealth.p2Shield8.gameObject.SetActive(true);
        uiHealth.p2Shield9.gameObject.SetActive(true);
        uiHealth.p2ShieldGone.gameObject.SetActive(false);
    }

    void Healthbar()
    {
        if (gameObject.CompareTag("Player1"))
        {
            if (health >= 90 && health <= 100)
            {
                uiHealth.bar1.gameObject.SetActive(true);
                uiHealth.bar2.gameObject.SetActive(true);
                uiHealth.bar3.gameObject.SetActive(true);
                uiHealth.bar4.gameObject.SetActive(true);
                uiHealth.bar5.gameObject.SetActive(true);
                uiHealth.bar6.gameObject.SetActive(true);
                uiHealth.bar7.gameObject.SetActive(true);
                uiHealth.bar8.gameObject.SetActive(true);
                uiHealth.bar9.gameObject.SetActive(true);
                uiHealth.gameOver.gameObject.SetActive(false);
            }
            if (health >= 80 && health < 90)
            {
                uiHealth.bar1.gameObject.SetActive(true);
                uiHealth.bar2.gameObject.SetActive(true);
                uiHealth.bar3.gameObject.SetActive(true);
                uiHealth.bar4.gameObject.SetActive(true);
                uiHealth.bar5.gameObject.SetActive(true);
                uiHealth.bar6.gameObject.SetActive(true);
                uiHealth.bar7.gameObject.SetActive(true);
                uiHealth.bar8.gameObject.SetActive(true);
                uiHealth.bar9.gameObject.SetActive(false);
                uiHealth.gameOver.gameObject.SetActive(false);
            }
            if (health >= 70 && health < 80)
            {
                uiHealth.bar1.gameObject.SetActive(true);
                uiHealth.bar2.gameObject.SetActive(true);
                uiHealth.bar3.gameObject.SetActive(true);
                uiHealth.bar4.gameObject.SetActive(true);
                uiHealth.bar5.gameObject.SetActive(true);
                uiHealth.bar6.gameObject.SetActive(true);
                uiHealth.bar7.gameObject.SetActive(true);
                uiHealth.bar8.gameObject.SetActive(false);
                uiHealth.bar9.gameObject.SetActive(false);
                uiHealth.gameOver.gameObject.SetActive(false);
            }
            if (health >= 60 && health < 70)
            {
                uiHealth.bar1.gameObject.SetActive(true);
                uiHealth.bar2.gameObject.SetActive(true);
                uiHealth.bar3.gameObject.SetActive(true);
                uiHealth.bar4.gameObject.SetActive(true);
                uiHealth.bar5.gameObject.SetActive(true);
                uiHealth.bar6.gameObject.SetActive(true);
                uiHealth.bar7.gameObject.SetActive(false);
                uiHealth.bar8.gameObject.SetActive(false);
                uiHealth.bar9.gameObject.SetActive(false);
                uiHealth.gameOver.gameObject.SetActive(false);
            }
            if (health >= 50 && health < 60)
            {
                uiHealth.bar1.gameObject.SetActive(true);
                uiHealth.bar2.gameObject.SetActive(true);
                uiHealth.bar3.gameObject.SetActive(true);
                uiHealth.bar4.gameObject.SetActive(true);
                uiHealth.bar5.gameObject.SetActive(true);
                uiHealth.bar6.gameObject.SetActive(false);
                uiHealth.bar7.gameObject.SetActive(false);
                uiHealth.bar8.gameObject.SetActive(false);
                uiHealth.bar9.gameObject.SetActive(false);
                uiHealth.gameOver.gameObject.SetActive(false);
            }
            if (health >= 40 && health < 50)
            {
                uiHealth.bar1.gameObject.SetActive(true);
                uiHealth.bar2.gameObject.SetActive(true);
                uiHealth.bar3.gameObject.SetActive(true);
                uiHealth.bar4.gameObject.SetActive(true);
                uiHealth.bar5.gameObject.SetActive(false);
                uiHealth.bar6.gameObject.SetActive(false);
                uiHealth.bar7.gameObject.SetActive(false);
                uiHealth.bar8.gameObject.SetActive(false);
                uiHealth.bar9.gameObject.SetActive(false);
                uiHealth.gameOver.gameObject.SetActive(false);
            }
            if (health >= 30 && health < 40)
            {
                uiHealth.bar1.gameObject.SetActive(true);
                uiHealth.bar2.gameObject.SetActive(true);
                uiHealth.bar3.gameObject.SetActive(true);
                uiHealth.bar4.gameObject.SetActive(false);
                uiHealth.bar5.gameObject.SetActive(false);
                uiHealth.bar6.gameObject.SetActive(false);
                uiHealth.bar7.gameObject.SetActive(false);
                uiHealth.bar8.gameObject.SetActive(false);
                uiHealth.bar9.gameObject.SetActive(false);
                uiHealth.gameOver.gameObject.SetActive(false);
            }
            if (health >= 20 && health < 30)
            {
                uiHealth.bar1.gameObject.SetActive(true);
                uiHealth.bar2.gameObject.SetActive(true);
                uiHealth.bar3.gameObject.SetActive(false);
                uiHealth.bar4.gameObject.SetActive(false);
                uiHealth.bar5.gameObject.SetActive(false);
                uiHealth.bar6.gameObject.SetActive(false);
                uiHealth.bar7.gameObject.SetActive(false);
                uiHealth.bar8.gameObject.SetActive(false);
                uiHealth.bar9.gameObject.SetActive(false);
                uiHealth.gameOver.gameObject.SetActive(false);
            }
            if (health >= 10 && health < 20)
            {
                uiHealth.bar1.gameObject.SetActive(true);
                uiHealth.bar2.gameObject.SetActive(false);
                uiHealth.bar3.gameObject.SetActive(false);
                uiHealth.bar4.gameObject.SetActive(false);
                uiHealth.bar5.gameObject.SetActive(false);
                uiHealth.bar6.gameObject.SetActive(false);
                uiHealth.bar7.gameObject.SetActive(false);
                uiHealth.bar8.gameObject.SetActive(false);
                uiHealth.bar9.gameObject.SetActive(false);
                uiHealth.gameOver.gameObject.SetActive(false);
            }
            if (health > 0 && health < 10)
            {
                uiHealth.bar1.gameObject.SetActive(false);
                uiHealth.bar2.gameObject.SetActive(false);
                uiHealth.bar3.gameObject.SetActive(false);
                uiHealth.bar4.gameObject.SetActive(false);
                uiHealth.bar5.gameObject.SetActive(false);
                uiHealth.bar6.gameObject.SetActive(false);
                uiHealth.bar7.gameObject.SetActive(false);
                uiHealth.bar8.gameObject.SetActive(false);
                uiHealth.bar9.gameObject.SetActive(false);
                uiHealth.gameOver.gameObject.SetActive(false);
            }
            if (health <= 0)
            {
                uiHealth.bar1.gameObject.SetActive(false);
                uiHealth.bar2.gameObject.SetActive(false);
                uiHealth.bar3.gameObject.SetActive(false);
                uiHealth.bar4.gameObject.SetActive(false);
                uiHealth.bar5.gameObject.SetActive(false);
                uiHealth.bar6.gameObject.SetActive(false);
                uiHealth.bar7.gameObject.SetActive(false);
                uiHealth.bar8.gameObject.SetActive(false);
                uiHealth.bar9.gameObject.SetActive(false);
                uiHealth.gameOver.gameObject.SetActive(true);
            }
        }

        if (gameObject.CompareTag("Player2"))
        {
            if (health >= 90 && health <= 100)
            {
                uiHealth.p2Bar1.gameObject.SetActive(true);
                uiHealth.p2Bar2.gameObject.SetActive(true);
                uiHealth.p2Bar3.gameObject.SetActive(true);
                uiHealth.p2Bar4.gameObject.SetActive(true);
                uiHealth.p2Bar5.gameObject.SetActive(true);
                uiHealth.p2Bar6.gameObject.SetActive(true);
                uiHealth.p2Bar7.gameObject.SetActive(true);
                uiHealth.p2Bar8.gameObject.SetActive(true);
                uiHealth.p2Bar9.gameObject.SetActive(true);
                uiHealth.p2GameOver.gameObject.SetActive(false);
            }
            if (health >= 80 && health < 90)
            {
                uiHealth.p2Bar1.gameObject.SetActive(true);
                uiHealth.p2Bar2.gameObject.SetActive(true);
                uiHealth.p2Bar3.gameObject.SetActive(true);
                uiHealth.p2Bar4.gameObject.SetActive(true);
                uiHealth.p2Bar5.gameObject.SetActive(true);
                uiHealth.p2Bar6.gameObject.SetActive(true);
                uiHealth.p2Bar7.gameObject.SetActive(true);
                uiHealth.p2Bar8.gameObject.SetActive(true);
                uiHealth.p2Bar9.gameObject.SetActive(false);
                uiHealth.p2GameOver.gameObject.SetActive(false);
            }
            if (health >= 70 && health < 80)
            {
                uiHealth.p2Bar1.gameObject.SetActive(true);
                uiHealth.p2Bar2.gameObject.SetActive(true);
                uiHealth.p2Bar3.gameObject.SetActive(true);
                uiHealth.p2Bar4.gameObject.SetActive(true);
                uiHealth.p2Bar5.gameObject.SetActive(true);
                uiHealth.p2Bar6.gameObject.SetActive(true);
                uiHealth.p2Bar7.gameObject.SetActive(true);
                uiHealth.p2Bar8.gameObject.SetActive(false);
                uiHealth.p2Bar9.gameObject.SetActive(false);
                uiHealth.p2GameOver.gameObject.SetActive(false);
            }
            if (health >= 60 && health < 70)
            {
                uiHealth.p2Bar1.gameObject.SetActive(true);
                uiHealth.p2Bar2.gameObject.SetActive(true);
                uiHealth.p2Bar3.gameObject.SetActive(true);
                uiHealth.p2Bar4.gameObject.SetActive(true);
                uiHealth.p2Bar5.gameObject.SetActive(true);
                uiHealth.p2Bar6.gameObject.SetActive(true);
                uiHealth.p2Bar7.gameObject.SetActive(false);
                uiHealth.p2Bar8.gameObject.SetActive(false);
                uiHealth.p2Bar9.gameObject.SetActive(false);
                uiHealth.p2GameOver.gameObject.SetActive(false);
            }
            if (health >= 50 && health < 60)
            {
                uiHealth.p2Bar1.gameObject.SetActive(true);
                uiHealth.p2Bar2.gameObject.SetActive(true);
                uiHealth.p2Bar3.gameObject.SetActive(true);
                uiHealth.p2Bar4.gameObject.SetActive(true);
                uiHealth.p2Bar5.gameObject.SetActive(true);
                uiHealth.p2Bar6.gameObject.SetActive(false);
                uiHealth.p2Bar7.gameObject.SetActive(false);
                uiHealth.p2Bar8.gameObject.SetActive(false);
                uiHealth.p2Bar9.gameObject.SetActive(false);
                uiHealth.p2GameOver.gameObject.SetActive(false);
            }
            if (health >= 40 && health < 50)
            {
                uiHealth.p2Bar1.gameObject.SetActive(true);
                uiHealth.p2Bar2.gameObject.SetActive(true);
                uiHealth.p2Bar3.gameObject.SetActive(true);
                uiHealth.p2Bar4.gameObject.SetActive(true);
                uiHealth.p2Bar5.gameObject.SetActive(false);
                uiHealth.p2Bar6.gameObject.SetActive(false);
                uiHealth.p2Bar7.gameObject.SetActive(false);
                uiHealth.p2Bar8.gameObject.SetActive(false);
                uiHealth.p2Bar9.gameObject.SetActive(false);
                uiHealth.p2GameOver.gameObject.SetActive(false);
            }
            if (health >= 30 && health < 40)
            {
                uiHealth.p2Bar1.gameObject.SetActive(true);
                uiHealth.p2Bar2.gameObject.SetActive(true);
                uiHealth.p2Bar3.gameObject.SetActive(true);
                uiHealth.p2Bar4.gameObject.SetActive(false);
                uiHealth.p2Bar5.gameObject.SetActive(false);
                uiHealth.p2Bar6.gameObject.SetActive(false);
                uiHealth.p2Bar7.gameObject.SetActive(false);
                uiHealth.p2Bar8.gameObject.SetActive(false);
                uiHealth.p2Bar9.gameObject.SetActive(false);
                uiHealth.p2GameOver.gameObject.SetActive(false);
            }
            if (health >= 20 && health < 30)
            {
                uiHealth.p2Bar1.gameObject.SetActive(true);
                uiHealth.p2Bar2.gameObject.SetActive(true);
                uiHealth.p2Bar3.gameObject.SetActive(false);
                uiHealth.p2Bar4.gameObject.SetActive(false);
                uiHealth.p2Bar5.gameObject.SetActive(false);
                uiHealth.p2Bar6.gameObject.SetActive(false);
                uiHealth.p2Bar7.gameObject.SetActive(false);
                uiHealth.p2Bar8.gameObject.SetActive(false);
                uiHealth.p2Bar9.gameObject.SetActive(false);
                uiHealth.p2GameOver.gameObject.SetActive(false);
            }
            if (health >= 10 && health < 20)
            {
                uiHealth.p2Bar1.gameObject.SetActive(true);
                uiHealth.p2Bar2.gameObject.SetActive(false);
                uiHealth.p2Bar3.gameObject.SetActive(false);
                uiHealth.p2Bar4.gameObject.SetActive(false);
                uiHealth.p2Bar5.gameObject.SetActive(false);
                uiHealth.p2Bar6.gameObject.SetActive(false);
                uiHealth.p2Bar7.gameObject.SetActive(false);
                uiHealth.p2Bar8.gameObject.SetActive(false);
                uiHealth.p2Bar9.gameObject.SetActive(false);
                uiHealth.p2GameOver.gameObject.SetActive(false);
            }
            if (health > 0 && health < 10)
            {
                uiHealth.p2Bar1.gameObject.SetActive(false);
                uiHealth.p2Bar2.gameObject.SetActive(false);
                uiHealth.p2Bar3.gameObject.SetActive(false);
                uiHealth.p2Bar4.gameObject.SetActive(false);
                uiHealth.p2Bar5.gameObject.SetActive(false);
                uiHealth.p2Bar6.gameObject.SetActive(false);
                uiHealth.p2Bar7.gameObject.SetActive(false);
                uiHealth.p2Bar8.gameObject.SetActive(false);
                uiHealth.p2Bar9.gameObject.SetActive(false);
                uiHealth.p2GameOver.gameObject.SetActive(false);
            }
            if (health <= 0)
            {
                uiHealth.p2Bar1.gameObject.SetActive(false);
                uiHealth.p2Bar2.gameObject.SetActive(false);
                uiHealth.p2Bar3.gameObject.SetActive(false);
                uiHealth.p2Bar4.gameObject.SetActive(false);
                uiHealth.p2Bar5.gameObject.SetActive(false);
                uiHealth.p2Bar6.gameObject.SetActive(false);
                uiHealth.p2Bar7.gameObject.SetActive(false);
                uiHealth.p2Bar8.gameObject.SetActive(false);
                uiHealth.p2Bar9.gameObject.SetActive(false);
                uiHealth.p2GameOver.gameObject.SetActive(true);
            }
        }
    }

    void Shieldbar()
    {
        if (gameObject.CompareTag("Player1"))
        {
            if (defence >= 90 && defence <= 100)
            {
                uiHealth.shield1.gameObject.SetActive(true);
                uiHealth.shield2.gameObject.SetActive(true);
                uiHealth.shield3.gameObject.SetActive(true);
                uiHealth.shield4.gameObject.SetActive(true);
                uiHealth.shield5.gameObject.SetActive(true);
                uiHealth.shield6.gameObject.SetActive(true);
                uiHealth.shield7.gameObject.SetActive(true);
                uiHealth.shield8.gameObject.SetActive(true);
                uiHealth.shield9.gameObject.SetActive(true);
                uiHealth.shieldGone.gameObject.SetActive(false);
            }
            if (defence >= 80 && defence < 90)
            {
                uiHealth.shield1.gameObject.SetActive(true);
                uiHealth.shield2.gameObject.SetActive(true);
                uiHealth.shield3.gameObject.SetActive(true);
                uiHealth.shield4.gameObject.SetActive(true);
                uiHealth.shield5.gameObject.SetActive(true);
                uiHealth.shield6.gameObject.SetActive(true);
                uiHealth.shield7.gameObject.SetActive(true);
                uiHealth.shield8.gameObject.SetActive(true);
                uiHealth.shield9.gameObject.SetActive(false);
                uiHealth.shieldGone.gameObject.SetActive(false);
            }
            if (defence >= 70 && defence < 80)
            {
                uiHealth.shield1.gameObject.SetActive(true);
                uiHealth.shield2.gameObject.SetActive(true);
                uiHealth.shield3.gameObject.SetActive(true);
                uiHealth.shield4.gameObject.SetActive(true);
                uiHealth.shield5.gameObject.SetActive(true);
                uiHealth.shield6.gameObject.SetActive(true);
                uiHealth.shield7.gameObject.SetActive(true);
                uiHealth.shield8.gameObject.SetActive(false);
                uiHealth.shield9.gameObject.SetActive(false);
                uiHealth.shieldGone.gameObject.SetActive(false);

            }
            if (defence >= 60 && defence < 70)
            {
                uiHealth.shield1.gameObject.SetActive(true);
                uiHealth.shield2.gameObject.SetActive(true);
                uiHealth.shield3.gameObject.SetActive(true);
                uiHealth.shield4.gameObject.SetActive(true);
                uiHealth.shield5.gameObject.SetActive(true);
                uiHealth.shield6.gameObject.SetActive(true);
                uiHealth.shield7.gameObject.SetActive(false);
                uiHealth.shield8.gameObject.SetActive(false);
                uiHealth.shield9.gameObject.SetActive(false);
                uiHealth.shieldGone.gameObject.SetActive(false);
            }
            if(defence >= 50 && defence < 60)
            {
                uiHealth.shield1.gameObject.SetActive(true);
                uiHealth.shield2.gameObject.SetActive(true);
                uiHealth.shield3.gameObject.SetActive(true);
                uiHealth.shield4.gameObject.SetActive(true);
                uiHealth.shield5.gameObject.SetActive(true);
                uiHealth.shield6.gameObject.SetActive(false);
                uiHealth.shield7.gameObject.SetActive(false);
                uiHealth.shield8.gameObject.SetActive(false);
                uiHealth.shield9.gameObject.SetActive(false);
                uiHealth.shieldGone.gameObject.SetActive(false);

            }
            if (defence >= 40 && defence < 50)
            {
                uiHealth.shield1.gameObject.SetActive(true);
                uiHealth.shield2.gameObject.SetActive(true);
                uiHealth.shield3.gameObject.SetActive(true);
                uiHealth.shield4.gameObject.SetActive(true);
                uiHealth.shield5.gameObject.SetActive(false);
                uiHealth.shield6.gameObject.SetActive(false);
                uiHealth.shield7.gameObject.SetActive(false);
                uiHealth.shield8.gameObject.SetActive(false);
                uiHealth.shield9.gameObject.SetActive(false);
                uiHealth.shieldGone.gameObject.SetActive(false);
            }
            if(defence >= 30 && defence < 40)
            {
                uiHealth.shield1.gameObject.SetActive(true);
                uiHealth.shield2.gameObject.SetActive(true);
                uiHealth.shield3.gameObject.SetActive(true);
                uiHealth.shield4.gameObject.SetActive(false);
                uiHealth.shield5.gameObject.SetActive(false);
                uiHealth.shield6.gameObject.SetActive(false);
                uiHealth.shield7.gameObject.SetActive(false);
                uiHealth.shield8.gameObject.SetActive(false);
                uiHealth.shield9.gameObject.SetActive(false);
                uiHealth.shieldGone.gameObject.SetActive(false);

            }
            if(defence >= 20 && defence < 30)
            {

                uiHealth.shield1.gameObject.SetActive(true);
                uiHealth.shield2.gameObject.SetActive(true);
                uiHealth.shield3.gameObject.SetActive(false);
                uiHealth.shield4.gameObject.SetActive(false);
                uiHealth.shield5.gameObject.SetActive(false);
                uiHealth.shield6.gameObject.SetActive(false);
                uiHealth.shield7.gameObject.SetActive(false);
                uiHealth.shield8.gameObject.SetActive(false);
                uiHealth.shield9.gameObject.SetActive(false);
                uiHealth.shieldGone.gameObject.SetActive(false);
            }
            if (defence >= 10 && defence < 20)
            {
                uiHealth.shield1.gameObject.SetActive(true);
                uiHealth.shield2.gameObject.SetActive(false);
                uiHealth.shield3.gameObject.SetActive(false);
                uiHealth.shield4.gameObject.SetActive(false);
                uiHealth.shield5.gameObject.SetActive(false);
                uiHealth.shield6.gameObject.SetActive(false);
                uiHealth.shield7.gameObject.SetActive(false);
                uiHealth.shield8.gameObject.SetActive(false);
                uiHealth.shield9.gameObject.SetActive(false);
                uiHealth.shieldGone.gameObject.SetActive(false);
            }
            if(defence > 0 && defence < 10)
            {
                uiHealth.shield1.gameObject.SetActive(true);
                uiHealth.shield2.gameObject.SetActive(false);
                uiHealth.shield3.gameObject.SetActive(false);
                uiHealth.shield4.gameObject.SetActive(false);
                uiHealth.shield5.gameObject.SetActive(false);
                uiHealth.shield6.gameObject.SetActive(false);
                uiHealth.shield7.gameObject.SetActive(false);
                uiHealth.shield8.gameObject.SetActive(false);
                uiHealth.shield9.gameObject.SetActive(false);
                uiHealth.shieldGone.gameObject.SetActive(false);
            }
            if(defence <= 0)
            {
                uiHealth.shield1.gameObject.SetActive(false);
                uiHealth.shield2.gameObject.SetActive(false);
                uiHealth.shield3.gameObject.SetActive(false);
                uiHealth.shield4.gameObject.SetActive(false);
                uiHealth.shield5.gameObject.SetActive(false);
                uiHealth.shield6.gameObject.SetActive(false);
                uiHealth.shield7.gameObject.SetActive(false);
                uiHealth.shield8.gameObject.SetActive(false);
                uiHealth.shield9.gameObject.SetActive(false);
                uiHealth.shieldGone.gameObject.SetActive(true);
            }
        }

        if (gameObject.CompareTag("Player2"))
        {
            if (defence >= 90 && defence <= 100)
            {
                uiHealth.p2Shield1.gameObject.SetActive(true);
                uiHealth.p2Shield2.gameObject.SetActive(true);
                uiHealth.p2Shield3.gameObject.SetActive(true);
                uiHealth.p2Shield4.gameObject.SetActive(true);
                uiHealth.p2Shield5.gameObject.SetActive(true);
                uiHealth.p2Shield6.gameObject.SetActive(true);
                uiHealth.p2Shield7.gameObject.SetActive(true);
                uiHealth.p2Shield8.gameObject.SetActive(true);
                uiHealth.p2Shield9.gameObject.SetActive(true);
                uiHealth.p2ShieldGone.gameObject.SetActive(false);
            }
            if (defence >= 80 && defence < 90)
            {
                uiHealth.p2Shield1.gameObject.SetActive(true);
                uiHealth.p2Shield2.gameObject.SetActive(true);
                uiHealth.p2Shield3.gameObject.SetActive(true);
                uiHealth.p2Shield4.gameObject.SetActive(true);
                uiHealth.p2Shield5.gameObject.SetActive(true);
                uiHealth.p2Shield6.gameObject.SetActive(true);
                uiHealth.p2Shield7.gameObject.SetActive(true);
                uiHealth.p2Shield8.gameObject.SetActive(true);
                uiHealth.p2Shield9.gameObject.SetActive(false);
                uiHealth.p2ShieldGone.gameObject.SetActive(false);
            }
            if (defence >= 70 && defence < 80)
            {
                uiHealth.p2Shield1.gameObject.SetActive(true);
                uiHealth.p2Shield2.gameObject.SetActive(true);
                uiHealth.p2Shield3.gameObject.SetActive(true);
                uiHealth.p2Shield4.gameObject.SetActive(true);
                uiHealth.p2Shield5.gameObject.SetActive(true);
                uiHealth.p2Shield6.gameObject.SetActive(true);
                uiHealth.p2Shield7.gameObject.SetActive(true);
                uiHealth.p2Shield8.gameObject.SetActive(false);
                uiHealth.p2Shield9.gameObject.SetActive(false);
                uiHealth.p2ShieldGone.gameObject.SetActive(false);
            }
            if (defence >= 60 && defence < 70)
            {
                uiHealth.p2Shield1.gameObject.SetActive(true);
                uiHealth.p2Shield2.gameObject.SetActive(true);
                uiHealth.p2Shield3.gameObject.SetActive(true);
                uiHealth.p2Shield4.gameObject.SetActive(true);
                uiHealth.p2Shield5.gameObject.SetActive(true);
                uiHealth.p2Shield6.gameObject.SetActive(true);
                uiHealth.p2Shield7.gameObject.SetActive(false);
                uiHealth.p2Shield8.gameObject.SetActive(false);
                uiHealth.p2Shield9.gameObject.SetActive(false);
                uiHealth.p2ShieldGone.gameObject.SetActive(false);
            }
            if (defence >= 50 && defence < 60)
            {
                uiHealth.p2Shield1.gameObject.SetActive(true);
                uiHealth.p2Shield2.gameObject.SetActive(true);
                uiHealth.p2Shield3.gameObject.SetActive(true);
                uiHealth.p2Shield4.gameObject.SetActive(true);
                uiHealth.p2Shield5.gameObject.SetActive(true);
                uiHealth.p2Shield6.gameObject.SetActive(false);
                uiHealth.p2Shield7.gameObject.SetActive(false);
                uiHealth.p2Shield8.gameObject.SetActive(false);
                uiHealth.p2Shield9.gameObject.SetActive(false);
                uiHealth.p2ShieldGone.gameObject.SetActive(false);

            }
            if (defence >= 40 && defence < 50)
            {
                uiHealth.p2Shield1.gameObject.SetActive(true);
                uiHealth.p2Shield2.gameObject.SetActive(true);
                uiHealth.p2Shield3.gameObject.SetActive(true);
                uiHealth.p2Shield4.gameObject.SetActive(true);
                uiHealth.p2Shield5.gameObject.SetActive(false);
                uiHealth.p2Shield6.gameObject.SetActive(false);
                uiHealth.p2Shield7.gameObject.SetActive(false);
                uiHealth.p2Shield8.gameObject.SetActive(false);
                uiHealth.p2Shield9.gameObject.SetActive(false);
                uiHealth.p2ShieldGone.gameObject.SetActive(false);
            }
            if (defence >= 30 && defence < 40)
            {
                uiHealth.p2Shield1.gameObject.SetActive(true);
                uiHealth.p2Shield2.gameObject.SetActive(true);
                uiHealth.p2Shield3.gameObject.SetActive(true);
                uiHealth.p2Shield4.gameObject.SetActive(false);
                uiHealth.p2Shield5.gameObject.SetActive(false);
                uiHealth.p2Shield6.gameObject.SetActive(false);
                uiHealth.p2Shield7.gameObject.SetActive(false);
                uiHealth.p2Shield8.gameObject.SetActive(false);
                uiHealth.p2Shield9.gameObject.SetActive(false);
                uiHealth.p2ShieldGone.gameObject.SetActive(false);

            }
            if (defence >= 20 && defence < 30)
            {
                uiHealth.p2Shield1.gameObject.SetActive(true);
                uiHealth.p2Shield2.gameObject.SetActive(true);
                uiHealth.p2Shield3.gameObject.SetActive(false);
                uiHealth.p2Shield4.gameObject.SetActive(false);
                uiHealth.p2Shield5.gameObject.SetActive(false);
                uiHealth.p2Shield6.gameObject.SetActive(false);
                uiHealth.p2Shield7.gameObject.SetActive(false);
                uiHealth.p2Shield8.gameObject.SetActive(false);
                uiHealth.p2Shield9.gameObject.SetActive(false);
                uiHealth.p2ShieldGone.gameObject.SetActive(false);

            }
            if (defence >= 10 && defence < 20)
            {

                uiHealth.p2Shield1.gameObject.SetActive(true);
                uiHealth.p2Shield2.gameObject.SetActive(false);
                uiHealth.p2Shield3.gameObject.SetActive(false);
                uiHealth.p2Shield4.gameObject.SetActive(false);
                uiHealth.p2Shield5.gameObject.SetActive(false);
                uiHealth.p2Shield6.gameObject.SetActive(false);
                uiHealth.p2Shield7.gameObject.SetActive(false);
                uiHealth.p2Shield8.gameObject.SetActive(false);
                uiHealth.p2Shield9.gameObject.SetActive(false);
                uiHealth.p2ShieldGone.gameObject.SetActive(false);
            }
            if (defence > 0 && defence < 10)
            {

                uiHealth.p2Shield1.gameObject.SetActive(true);
                uiHealth.p2Shield2.gameObject.SetActive(false);
                uiHealth.p2Shield3.gameObject.SetActive(false);
                uiHealth.p2Shield4.gameObject.SetActive(false);
                uiHealth.p2Shield5.gameObject.SetActive(false);
                uiHealth.p2Shield6.gameObject.SetActive(false);
                uiHealth.p2Shield7.gameObject.SetActive(false);
                uiHealth.p2Shield8.gameObject.SetActive(false);
                uiHealth.p2Shield9.gameObject.SetActive(false);
                uiHealth.p2ShieldGone.gameObject.SetActive(false);
            }
            if (defence <= 0)
            {
                uiHealth.p2Shield1.gameObject.SetActive(false);
                uiHealth.p2Shield2.gameObject.SetActive(false);
                uiHealth.p2Shield3.gameObject.SetActive(false);
                uiHealth.p2Shield4.gameObject.SetActive(false);
                uiHealth.p2Shield5.gameObject.SetActive(false);
                uiHealth.p2Shield6.gameObject.SetActive(false);
                uiHealth.p2Shield7.gameObject.SetActive(false);
                uiHealth.p2Shield8.gameObject.SetActive(false);
                uiHealth.p2Shield9.gameObject.SetActive(false);
                uiHealth.p2ShieldGone.gameObject.SetActive(true);
            }
        }
    }

    void StatCheck()
    {
        if (defence > maxDefence)
        {
            defence = maxDefence;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
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
                isPlayer1FinalD = true;


            }
            if (gameObject.CompareTag("Player2"))
            {
                lBoard.p2Death = lBoard.p2Death + 1;
                isPlayer2FinalD = true;

            }

            Destroy(gameObject);
        }
    }
}
