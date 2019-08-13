using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Set conditions for char to play attack animations
/// </summary>

[RequireComponent(typeof(CharacterAnimations))]
[RequireComponent(typeof(AudioSource))]

public class PlayerAtkAnimations : MonoBehaviour
{
    CharacterAnimations playerAtkAnimations;
    private AudioSource audioSource;
    public AudioClip sword, fireArrow, fireBall;

    void Start()
    {
        playerAtkAnimations = GetComponent<CharacterAnimations>();
        audioSource = GetComponent<AudioSource>();
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
                    case "Warrior" :
                        playerAtkAnimations.Atk_Warrior();
                        GetComponent<AudioSource>().PlayOneShot(sword);
                        break;

                    case "Rogue":
                        playerAtkAnimations.Attack_Rogue();
                        GetComponent<AudioSource>().PlayOneShot(fireArrow);
                        //audioSource.clip = fireArrow;
                        //audioSource.Play();
                        break;

                    case "Mage":
                        playerAtkAnimations.Attack_Mage();
                        GetComponent<AudioSource>().PlayOneShot(fireBall);
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
                    case "Warrior":
                        playerAtkAnimations.Atk_Warrior();
                        GetComponent<AudioSource>().PlayOneShot(sword);
                        break;

                    case "Rogue":
                        playerAtkAnimations.Attack_Rogue();
                        GetComponent<AudioSource>().PlayOneShot(fireArrow);
                        break;

                    case "Mage":
                        playerAtkAnimations.Attack_Mage();
                        GetComponent<AudioSource>().PlayOneShot(fireBall);
                        break;
                }
            }
        }
    }

  
    


}
