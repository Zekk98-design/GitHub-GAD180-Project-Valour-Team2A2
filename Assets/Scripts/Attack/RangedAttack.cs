using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public int playerNo;
    [SerializeField] private GameObject arrow;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        TagFind();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNo == 1 & Input.GetKeyDown(KeyCode.E))
        {
            GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation);
            newArrow.GetComponent<Collider>().enabled = true;
            newArrow.GetComponent<ArrowScript>().owner = GameObject.FindWithTag("Player1");
        }

        if (playerNo == 2 & Input.GetKeyDown(KeyCode.O))
        {
            GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation);
            newArrow.GetComponent<Collider>().enabled = true;
            newArrow.GetComponent<ArrowScript>().owner = GameObject.FindWithTag("Player2");
        }
    }

    public void TagFind()
    {
        if (gameObject.transform.parent.CompareTag("Player1"))
        {
            playerNo = 1;
        }

        if (gameObject.transform.parent.CompareTag("Player2"))
        {
            playerNo = 2;
        }
    }
}
