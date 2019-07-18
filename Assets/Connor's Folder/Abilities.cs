using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [SerializeField] private GameObject fireball;
    [SerializeField] private int chargeMax;
    public int charge = 15;
    private string warrior = "Warrior Tpose";
    private string rogue = "Rogue Tpose";
    private string mage = "Mage Tpose";

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == warrior)
        {
            chargeMax = 15;
        }
        if (gameObject.name == rogue)
        {
            chargeMax = 10;
        }
        if (gameObject.name == mage)
        {
            chargeMax = 15;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player1")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (gameObject.name == warrior)     // Warrior Weapon Switch
                {
                    if (charge == chargeMax)
                    {
                        PlayerStats playerStats = gameObject.GetComponent<PlayerStats>();

                        if (playerStats.state == 1)
                        {
                            playerStats.damage = playerStats.damage + 10;

                            if (playerStats.defence > 80)
                            {
                                playerStats.defence = playerStats.defence - 10;
                            }

                            playerStats.state = 2;
                        }

                        if (playerStats.state == 2)
                        {
                            playerStats.damage = playerStats.damage - 10;
                        }
                        charge = 0;
                    }
                }

                if (gameObject.name == rogue)       // Rogue Dodge skill
                {
                    if (charge == chargeMax)
                    {
                        transform.Translate(0, 0, 2.0f);
                        charge = 0;
                    }
                }

                if (gameObject.name == mage)        //Mage Fireball skill
                {
                    if (charge == chargeMax)
                    {
                        GameObject newFire = Instantiate(fireball, transform.position, transform.rotation);
                        newFire.GetComponent<Collider>().enabled = true;
                        newFire.GetComponent<Fireball>().owner = gameObject;
                        charge = 0;
                    }
                }
            }
        }

        if (gameObject.tag == "Player2")
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                if (gameObject.name == warrior)     // Warrior Weapon Switch
                {
                    if (charge == chargeMax)
                    {
                        PlayerStats playerStats = gameObject.GetComponent<PlayerStats>();

                        if (playerStats.state == 1)
                        {
                            playerStats.damage = playerStats.damage + 10;

                            if (playerStats.defence > 80)
                            {
                                playerStats.defence = playerStats.defence - 10;
                            }

                            playerStats.state = 2;
                        }

                        if (playerStats.state == 2)
                        {
                            playerStats.damage = playerStats.damage - 10;
                        }
                        charge = 0;
                    }
                }

                if (gameObject.name == rogue)       // Rogue Dodge skill
                {
                    if (charge == chargeMax)
                    {
                        transform.Translate(0, 0, 2.0f);
                        charge = 0;
                    }
                }

                if (gameObject.name == mage)        //Mage Fireball skill
                {
                    if (charge == chargeMax)
                    {
                        GameObject newFire = Instantiate(fireball, transform.position, transform.rotation);
                        newFire.GetComponent<Collider>().enabled = true;
                        newFire.GetComponent<Fireball>().owner = gameObject;
                        charge = 0;
                    }
                }
            }
        }
    }
}
