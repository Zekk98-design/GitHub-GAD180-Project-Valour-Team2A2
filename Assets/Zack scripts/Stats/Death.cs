using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("HAHAHAHAHAHAHAHAH");
        Debug.Log("Health is currently: [" + GameControlScript.health + "].");
        GameControlScript.health -= 1;
        Debug.Log("Health is now (after DEATH): [" + GameControlScript.health + "].");
    }
}