using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGain : MonoBehaviour
{
    // Add to health potions so that the player gains health when colliding with them.

    void OnTriggerEnter(Collider collider)
    {
        GameControlScript.health += 1;
    }
}