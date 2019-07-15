using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    private string pTag;
    public string p1Char;
    public string p2Char;
    public Button P1Warrior, P2Warrior, P1Rogue, P2Rogue, P1Mage, P2Mage;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        P1Warrior.onClick.AddListener(delegate { GetTag(pTag); });
    }

    private string GetTag(string pTag)
    {
        pTag = gameObject.tag;
        return pTag;
    }

    public void CharSelect(string pTag)
    {
        print(pTag);

        if (pTag == "P1Warrior" || pTag == "P1Rogue" || pTag == "P1Mage")
        {
            p1Char = pTag;
        }

        if (pTag == "P2Warrior" || pTag == "P2Rogue" || pTag == "P2Mage")
        {
            p2Char = pTag;
        }
    }
}
