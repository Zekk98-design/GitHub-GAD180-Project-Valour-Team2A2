using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGain : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        GameControlScript.health += 1;
    }
}