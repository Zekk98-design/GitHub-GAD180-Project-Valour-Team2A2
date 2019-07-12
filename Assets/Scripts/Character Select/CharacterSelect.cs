using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    private string pTag;
    public Button P1Warrior, P2Warrior, P1Rogue, P2Rogue, P1Mage, P2Mage;

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
    }
}
