using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is used to connect script and condition parameters in Animator Controller 
/// Attach this code to characters
/// </summary>

[RequireComponent(typeof(Animator))]

public class CharacterAnimations : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        // Initialise the Animator component for anim;
        anim = GetComponent<Animator>();
    }

    // Set the condition value for Walk animation, 
    public void Walk(bool walk)
    {
        anim.SetBool("Walk", walk);
    }

    //******************************** Animations for Warrior ************************************************* //
    #region Animations for Warrior ...

    //set the condition value for Warrior attack
    public void Atk_Warrior()
    {
        anim.SetTrigger("Attack Warrior");
    }
    //Ability attack
    public void Ability_Atk_Warrior()
    {
        anim.SetTrigger("Ability Warrior");
    }

    #endregion

    //******************************** Animations for Rogue ************************************************* //
    #region Animations for Rogue ...

    //set the condition value for Rogue attack
    public void Attack_Rogue()
    {
        anim.SetTrigger("Attack Rogue");
    }


    public void Dodge()
    {
        anim.SetTrigger("Dodge");

    }

    #endregion

    //******************************** Animations for Mage ************************************************* //
    #region Animations for Mage ...

    //set the condition value for Mage Attack
    public void Attack_Mage()
    {
        anim.SetTrigger("Attack Mage");
    }

    public void Fireball()
    {
        anim.SetTrigger("Fireball");
    }

    #endregion

    //******************************** Animations Patron ************************************************* //
    public void Atk_Patron()
    {
        anim.SetTrigger("Attack Patron");
    }
         

    //******************************** Animations for Bartender ************************************************* //
    public void Atk_Bartender()
    {
        anim.SetTrigger("Attack Bartender");
    }
    //Ability attack
    public void Ability_Bartender()
    {
        anim.SetTrigger("Ability Bartender");
    }

    //******************************** Animations Chicken ************************************************* //
    public void Atk_Chicken()
    {
        anim.SetTrigger("Attack Chicken");
    }

    //******************************** Animations for Bull ************************************************* //
    public void Atk_Bull()
    {
        anim.SetTrigger("Attack Bull");
    }
    //Ability attack
    public void Ability_Bull()
    {
        anim.SetTrigger("Ability Bull");
        
    }


}