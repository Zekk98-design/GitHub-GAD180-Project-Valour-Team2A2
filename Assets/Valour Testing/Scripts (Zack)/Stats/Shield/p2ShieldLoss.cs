using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2ShieldLoss : MonoBehaviour
{
    // Shieldloss Script.
    // Add to enemies so that when they collide with/hit the palyer, the player will lose Shield.

    void OnTriggerEnter(Collider collider)
    {
        GameControlScriptShield.p2Shield -= 1;
    }
}