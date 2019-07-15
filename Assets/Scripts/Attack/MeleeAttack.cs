using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public PlayerStats playerStats;
    public bool isWeapon;

    private void OnCollisionEnter(Collision collision)                                      // Check collision
    {
        if (collision.gameObject.tag == "Enemy")                                            // Compare collision with tag
        {
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();        // Get stats on collided enemy

            if (isWeapon == true & enemyStats.defence > 0)
            {
                enemyStats.defence = enemyStats.defence - playerStats.damage;
            }

            if (isWeapon == true & enemyStats.defence < 0)
            {
                enemyStats.health = enemyStats.health - playerStats.damage;                 // if weapon, deal damage
            }

            if (isWeapon == false & playerStats.defence > 0)
            {
                playerStats.defence = playerStats.defence - enemyStats.damage;                // if not weapon, take damage
            }

            if (isWeapon == false & playerStats.defence < 0)
            {
                playerStats.health = playerStats.health - enemyStats.damage;
            }
        }
    }
}
