using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2HealthGain : MonoBehaviour
{
    // Add to health potions so that the player gains health when colliding with them.

    void OnTriggerEnter(Collider collider)
    {
        GameControlScript.p2Health += 1;
    }
}