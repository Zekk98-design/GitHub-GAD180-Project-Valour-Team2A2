using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFunction : MonoBehaviour
{
    public EnemyStats enemyStats;
    public PlayerStats playerStats;
    public bool isWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
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
