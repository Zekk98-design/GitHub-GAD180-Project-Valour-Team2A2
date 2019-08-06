using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPauser : MonoBehaviour
{
    public bool timer = true;
    public bool eSpawn = true;
    public bool eAI = true;
    public bool pControl = true;

    //switching bool status for controls and ai
    public void Switch()
    {
        timer = !timer;
        eSpawn = !eSpawn;
        eAI = !eAI;
        pControl = !pControl;
    }
}
