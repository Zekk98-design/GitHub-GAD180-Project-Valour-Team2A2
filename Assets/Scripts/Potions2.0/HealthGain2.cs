using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGain2 : MonoBehaviour
{
    public PlayerStats playerStats;
    public bool start = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            playerStats = other.gameObject.GetComponent<PlayerStats>();
            if (playerStats.health < playerStats.maxHealth)
            {
                playerStats.health = playerStats.health + 30;
                start = true;
            }
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            playerStats = other.gameObject.GetComponent<PlayerStats>();
            if (playerStats.health < playerStats.maxHealth)
            {
                playerStats.health = playerStats.health + 30;
                start = true;
            }
        }
    }
}
