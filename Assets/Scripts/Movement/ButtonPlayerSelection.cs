using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Player control selection button
/// Attached to PlayerSelectionMenue under Canvas
/// </summary>

public class ButtonPlayerSelection : MonoBehaviour
{
    public CharactersMovement[] charactersM;

    void Awake()
    {
       
    }

    public void Player1Select()
    {
        charactersM[0].isPlayer1 = true; // Put Warrior model in Inspector
        charactersM[1].isPlayer1 = true; // Put Rogue model in Inspector
        charactersM[2].isPlayer1 = true; // Put Mage model in Inspector

    }


    public void Player2Select()
    {
        charactersM[0].isPlayer1 = false;
        charactersM[1].isPlayer1 = false;
        charactersM[2].isPlayer1 = false;

    }



}
