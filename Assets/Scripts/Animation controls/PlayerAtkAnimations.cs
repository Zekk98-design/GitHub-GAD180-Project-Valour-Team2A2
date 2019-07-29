using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Set conditions for char to play attack animations
/// </summary>

[RequireComponent(typeof(CharacterAnimations))]

public class PlayerAtkAnimations : MonoBehaviour
{
    CharacterAnimations playerAtkAnimations;

    void Start()
    {
        playerAtkAnimations = GetComponent<CharacterAnimations>();

    }

    void Update()
    {
        NormalAttack();
        

    }

    //Characters normal attack animation
    void NormalAttack()
    {
        if (gameObject.CompareTag("Player1"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (gameObject.name)
                {
                    case "warrior" :
                        playerAtkAnimations.Atk_Warrior();
                        break;

                    case "rogue":
                        playerAtkAnimations.Attack_Rogue();
                        break;

                    case "mage":
                        playerAtkAnimations.Attack_Mage();
                        break;
                }
            }
        }

        if (gameObject.CompareTag("Player2"))
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                switch (gameObject.name)
                {
                    case "warrior":
                        playerAtkAnimations.Atk_Warrior();
                        break;

                    case "rogue":
                        playerAtkAnimations.Attack_Rogue();
                        break;

                    case "mage":
                        playerAtkAnimations.Attack_Mage();
                        break;
                }
            }
        }
    }



    //Characters ability attack animation
    //void Ability()
    //{
    //    if (gameObject.CompareTag("Player1"))
    //    {
    //        if (Input.GetKeyDown(KeyCode.Q))
    //        {
    //            switch (gameObject.name)
    //            {
    //                case "warrior":
    //                    playerAtkAnimations.Ability_Atk_Warrior();
    //                    break;

    //                case "rogue":
    //                    playerAtkAnimations.Dodge();
    //                    break;

    //                case "mage":
    //                    playerAtkAnimations.Fireball();
    //                    break;
    //            }
    //        }
    //    }

    //    if (gameObject.CompareTag("Player2"))
    //    {
    //        if (Input.GetKeyDown(KeyCode.U))
    //        {
    //            switch (gameObject.name)
    //            {
    //                case "warrior":
    //                    playerAtkAnimations.Ability_Atk_Warrior();
    //                    break;

    //                case "rogue":
    //                    playerAtkAnimations.Dodge();
    //                    break;

    //                case "mage":
    //                    playerAtkAnimations.Fireball();
    //                    break;
    //            }
    //        }
    //    }

    //}   
    


}
