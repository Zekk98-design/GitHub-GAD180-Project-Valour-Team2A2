using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldLoss : MonoBehaviour
{
    // Shieldloss Script.
    // Add to enemies so that when they collide with/hit the palyer, the player will lose Shield.

    void OnTriggerEnter(Collider collider)
    {
        GameControlScriptShield.shield -= 1;
    }
}