using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Leaderboard lBoard;
    public PlayerStats playerStats;
    public bool isWeapon;

    

    private void Start()
    {
        GameObject EGO = GameObject.Find("Game Manager");
        lBoard = EGO.GetComponent<Leaderboard>();
    }

    private void OnTriggerEnter(Collider other)                                      // Check collision
    {
        if (other.gameObject.tag == "Enemy")                                            // Compare collision with tag
        {
            EnemyStats enemyStats = other.gameObject.GetComponent<EnemyStats>();             // Get stats on collided enemy
 
            if (isWeapon == true && enemyStats.defence > 0 )
            {
                enemyStats.defence = enemyStats.defence - playerStats.damage ;
                                
                if (gameObject.CompareTag("Player1"))
                {
                    lBoard.p1Dmg = lBoard.p1Dmg + playerStats.damage;
                }
                if (gameObject.CompareTag("Player2"))
                {
                    lBoard.p2Dmg = lBoard.p2Dmg + playerStats.damage;
                }
            }

            if (isWeapon == true && enemyStats.defence <= 0)
            {
                enemyStats.health = enemyStats.health - playerStats.damage;                 // if weapon, deal damage
                
                if (gameObject.CompareTag("Player1"))
                {
                    lBoard.p1Dmg = lBoard.p1Dmg + playerStats.damage;
                }
                if (gameObject.CompareTag("Player2"))
                {
                    lBoard.p2Dmg = lBoard.p2Dmg + playerStats.damage;
                }
            }

          
        }
        else
        {
            return;
        }
    }
}
