using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player1")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (gameObject.name == "Warrior Tpose")
                {
                    //
                }

                if (gameObject.name == "Rogue Tpose")
                {
                    //
                }

                if (gameObject.name == "Mage Tpose")
                {
                    
                }
            }
        }

        if (gameObject.tag == "Player2")
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                if (gameObject.name == "Warrior Tpose")
                {
                    //
                }

                if (gameObject.name == "Rogue Tpose")
                {
                    //
                }

                if (gameObject.name == "Mage Tpose")
                {
                    //
                }
            }
        }
    }
}
