using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGain : MonoBehaviour
{
    // Add to shield potions (green) so that the player gains shield when colliding with them.

    void OnTriggerEnter(Collider collider)
    {
        GameControlScriptShield.shield += 1;
    }
}