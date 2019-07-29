using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2ShieldGain : MonoBehaviour
{
    // Add to shield potions (green) so that the player gains shield when colliding with them.

    void OnTriggerEnter(Collider collider)
    {
        GameControlScriptShield.p2Shield += 1;
    }
}