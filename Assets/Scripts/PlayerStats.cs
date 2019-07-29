using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Leaderboard lBoard;
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
    }
}
