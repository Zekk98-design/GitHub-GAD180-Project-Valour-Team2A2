using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInstantiate : MonoBehaviour
{
    private CharacterSelect charSelect;
    [SerializeField] private GameObject Warrior;
    [SerializeField] private GameObject Rogue;
    [SerializeField] private GameObject Mage;
    private string p1Char;
    private string p2Char;
    private Vector3 p1Spawn;
    private Vector3 p2Spawn;

    // Start is called before the first frame update
    void Start()
    {
        charSelect = GameObject.Find("EGO Select").GetComponent<CharacterSelect>();
        p1Spawn = transform.position + new Vector3(0, 0, 0);
        p2Spawn = transform.position + new Vector3(1, 0, 1);

        if (charSelect.p1Char == "P1Warrior")
        {
            GameObject P1 = Instantiate(Warrior, p1Spawn, transform.rotation);
            P1.gameObject.tag = "Player1";
            P1.gameObject.name = "warrior"; //added by Bruce
;        }

        if (charSelect.p2Char == "P2Warrior")
        {
            GameObject P1 = Instantiate(Warrior, p2Spawn, transform.rotation);
            P1.gameObject.tag = "Player2";
            P1.gameObject.name = "warrior"; //added by Bruce
        }

        if (charSelect.p1Char == "P1Rogue")
        {
            GameObject P1 = Instantiate(Rogue, p1Spawn, transform.rotation);
            P1.gameObject.tag = "Player1";
            P1.gameObject.name = "rogue"; //added by Bruce
        }

        if (charSelect.p2Char == "P2Rogue")
        {
            GameObject P1 = Instantiate(Rogue, p2Spawn, transform.rotation);
            P1.gameObject.tag = "Player2";
            P1.gameObject.name = "rogue"; //added by Bruce
        }

        if (charSelect.p1Char == "P1Mage")
        {
            GameObject P1 = Instantiate(Mage, p1Spawn, transform.rotation);
            P1.gameObject.tag = "Player1";
            P1.gameObject.name = "mage"; //added by Bruce
        }

        if (charSelect.p2Char == "P2Mage")
        {
            GameObject P1 = Instantiate(Mage, p2Spawn, transform.rotation);
            P1.gameObject.tag = "Player2";
            P1.gameObject.name = "mage"; //added by Bruce
        }
    }
}
