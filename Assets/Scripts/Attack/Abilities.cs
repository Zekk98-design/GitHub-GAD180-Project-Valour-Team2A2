using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Originally created by Charlie.
/// Bruce made some modifications
/// </summary>

[RequireComponent(typeof(CharacterAnimations))]  //added by Bruce
[RequireComponent(typeof(PlayerStats))]  //added by Bruce
[RequireComponent(typeof (BasicMove))] //added by Bruce

public class Abilities : MonoBehaviour
{
    [SerializeField] private GameObject fireball;
    [SerializeField] private int chargeMax;
    CharacterAnimations playerAtkAnimations;
    BasicMove basicMove;  //added by Bruce

    public int charge = 15;
    
    void Start()
    {
        if (gameObject.name == "Warrior")
        {
            chargeMax = 15;
        }
        if (gameObject.name == "Rogue")
        {
            chargeMax = 15;
        }
        if (gameObject.name == "Mage")
        {
            chargeMax = 15;
        }

        playerAtkAnimations = GetComponent<CharacterAnimations>(); //added by bruce
        basicMove = GetComponent<BasicMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player1")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (gameObject.name == "Warrior")     // Warrior Weapon Switch
                {
                    if (charge == chargeMax)
                    {
                        PlayerStats playerStats = gameObject.GetComponent<PlayerStats>(); 

                        playerAtkAnimations.Ability_Atk_Warrior(); //play animation added by bruce

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

                if (gameObject.name == "Rogue")       // Rogue Dodge skill
                {
                    if (charge == chargeMax)
                    {
                        playerAtkAnimations.Dodge(); //added bu Bruce
                        transform.Translate(0, 0, -3.0f);
                        transform.rotation = Quaternion.LookRotation(basicMove.movement); //added bu Bruce
                        charge = 0;
                    }
                }

                if (gameObject.name == "Mage")        //Mage Fireball skill
                {
                    if (charge == chargeMax)
                    {
                        playerAtkAnimations.Fireball(); //added by bruce
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
                if (gameObject.name == "Warrior")     // Warrior Weapon Switch
                {
                    if (charge == chargeMax)
                    {
                        PlayerStats playerStats = gameObject.GetComponent<PlayerStats>();
                        playerAtkAnimations.Ability_Atk_Warrior(); //play animation added by bruce

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

                if (gameObject.name == "Rogue")       // Rogue Dodge skill
                {
                    if (charge == chargeMax)
                    {
                        playerAtkAnimations.Dodge(); //added bu Bruce
                        transform.Translate(0, 0, -3.0f);
                        transform.rotation = Quaternion.LookRotation(basicMove.movement); //added bu Bruce
                        charge = 0;
                    }
                }

                if (gameObject.name == "Mage")        //Mage Fireball skill
                {
                    if (charge == chargeMax)
                    {
                        playerAtkAnimations.Fireball(); //added by bruce
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
