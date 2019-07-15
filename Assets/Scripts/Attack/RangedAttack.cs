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
            newArrow.GetComponent<ArrowScript>().owner = gameObject;
        }

        if (playerNo == 2 & Input.GetKeyDown(KeyCode.O))
        {
            GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation);
            newArrow.GetComponent<Collider>().enabled = true;
            newArrow.GetComponent<ArrowScript>().owner = gameObject;
        }
    }

    public void TagFind()
    {
        if (gameObject.CompareTag("Player1"))
        {
            playerNo = 1;
        }

        if (gameObject.CompareTag("Player2"))
        {
            playerNo = 2;
        }
    }
}
