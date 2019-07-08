using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFunction : MonoBehaviour
{
    public PlayerStats playerStats;
    public bool isWeapon;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();

            if (isWeapon == true)
            {
                enemyStats.health = enemyStats.health - playerStats.damage;
            }

            if (isWeapon == false)
            {
                playerStats.health = playerStats.health - enemyStats.damage;
            }
        }
    }
}
