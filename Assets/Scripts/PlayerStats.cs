using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 20;
    public float damage = 3;
    public float defence = 20;
    public float health;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HP: " + health;

        if (health <= 0)
        {
            health = 0;

            // play death animation

            Destroy(gameObject);
        }
    }
}
